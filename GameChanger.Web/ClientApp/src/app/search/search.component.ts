import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { UntypedFormControl } from '@angular/forms';
import { debounceTime, tap, switchMap, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

export class SearchComponent {

  searchTeamsControl = new UntypedFormControl();
  filteredTeams: any;
  isLoading = false;
  errorMsg: string | undefined;

  constructor(private postService: PostService, private router: Router) { }

  ngOnInit() {
    this.searchTeamsControl.valueChanges
      .pipe(
        debounceTime(500),
        tap(() => {
          this.errorMsg = "";
          this.filteredTeams = [];
          this.isLoading = true;
        }),
        switchMap(value => this.postService.searchTeams(value)
          .pipe(
            finalize(() => {
              this.isLoading = false
            }),
          )
        )
      )
      .subscribe(data => {
        if (data == undefined) {
          this.errorMsg = data;
          this.filteredTeams = [];
        } else {
          this.errorMsg = "";
          this.filteredTeams = data;
        }
      });
  }

  itemSelected(item: any) {
    if (item.option.value == "88daa9da-99f7-473e-995c-dcc465759cf4") {
      this.router.navigate(['/']).then(() => {
        window.location.reload();
      });
    } else {
      this.router.navigate(['/teams/' + item.option.value + '/schedule']).then(() => {
        window.location.reload();
      });
    }
  }

}
