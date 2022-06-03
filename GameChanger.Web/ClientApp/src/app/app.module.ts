import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TeamNavBarComponent } from './team-nav-bar/team-nav-bar.component';
import { HomeComponent } from './home/home.component';
import { StatsComponent } from './stats/stats.component';
import { SearchComponent } from './search/search.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material.module';
import { SprayChartComponent } from './spray-chart/sparychart.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TeamNavBarComponent,
    HomeComponent,
    StatsComponent,
    SearchComponent,
    ScheduleComponent,
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
      { path: 'teams/:teamId/schedule', component: ScheduleComponent },
      { path: 'teams/:teamId/season-stats', component: StatsComponent },
      { path: 'teams/:teamId/spray-charts', component: SprayChartComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
