import { Component, Input, OnInit } from '@angular/core';
import { Stats, Stats2 } from '../../models/teamStat';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})

export class StatsComponent {

  @Input() team: any;
  @Input() players: any;
  @Input() info: any;
  constructor() {}


}
