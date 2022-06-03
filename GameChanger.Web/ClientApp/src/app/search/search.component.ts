import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { FormControl } from '@angular/forms';
import { debounceTime, tap, switchMap, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

export class SearchComponent {

  searchTeamsControl = new FormControl();
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
    this.router.navigate(['/teams/' + item.option.value + '/schedule']).then(() => {
      window.location.reload();
    });
  }

}
