import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { StatsComponent } from './team/stats/stats.component';
import { SearchComponent } from './search/search.component';
import { TeamComponent } from './team/team.component';
import { ScheduleComponent } from './team/schedule/schedule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material.module';
import { EventsComponent } from './team/events/events.component';
import { SprayChartComponent } from './team/spray-chart/sparychart.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StatsComponent,
    SearchComponent,
    TeamComponent,
    ScheduleComponent,
    EventsComponent,
    SprayChartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'search', component: SearchComponent },
      { path: 'team/:teamId', component: TeamComponent },
      { path: 'team/:teamId/spray-chart', component: SprayChartComponent },
      { path: 'team/:teamId/schedule/events/:eventId', component: EventsComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
