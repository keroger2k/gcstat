import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { PostService } from '../../services/post.service';
import { PlayerSprayRoot } from '../../models/spraychart'


@Component({
  selector: 'app-spray-chart',
  templateUrl: './spraychart.component.html',
  styleUrls: ['./spraychart.component.css']
})
export class SprayChartComponent implements OnInit {

  teamId: string | undefined;
  routeSub: Subscription = new Subscription;
  playerSprayInfo: Array<PlayerSprayRoot> | undefined;

  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;
      console.log("spray-chart:" + this.teamId);

      this.postService.teamSprayData(params.teamId).subscribe(results => {
        this.playerSprayInfo = results;
      })
    });
  }

  convertCoordinates(item: Coords) {
    return convertFromLegacy(item);
  }
}

// Home base is at
const systemHomePlateX = 160;
const systemHomePlateY = 295;
// First Base is at
const systemFirstBaseX = 211.25;
const systemFirstBaseY = 246;

const LEGACY_HOME_PLATE_X = 160;
const LEGACY_HOME_PLATE_Y = 296;
const LEGACY_FIRST_BASE_X = 234;
const LEGACY_FIRST_BASE_Y = 220;

export const LEGACY_HOME_PLATE_COORDS: Coords = {
  x: LEGACY_HOME_PLATE_X,
  y: LEGACY_HOME_PLATE_Y,
};
export const LEGACY_FIRST_BASE_COORDS: Coords = {
  x: LEGACY_FIRST_BASE_X,
  y: LEGACY_FIRST_BASE_Y,
};
export const SYSTEM_HOME_PLATE_COORDS: Coords = {
  x: systemHomePlateX,
  y: systemHomePlateY,
};
export const SYSTEM_FIRST_BASE_COORDS: Coords = {
  x: systemFirstBaseX,
  y: systemFirstBaseY,
};

const xSystemPerLegacy = (systemHomePlateX - systemFirstBaseX) / (LEGACY_HOME_PLATE_X - LEGACY_FIRST_BASE_X);
const ySystemPerLegacy = (systemHomePlateY - systemFirstBaseY) / (LEGACY_HOME_PLATE_Y - LEGACY_FIRST_BASE_Y);
const xSystemLocationOfLegacyOrigin = systemHomePlateX - LEGACY_HOME_PLATE_X * xSystemPerLegacy;
const ySystemLocationOfLegacyOrigin = systemHomePlateY - LEGACY_HOME_PLATE_Y * ySystemPerLegacy;

export type Coords = {
  x: number;
  y: number;
};

export const convertFromLegacy = (location: Coords): Coords => {
  const { x, y } = location;
  return {
    x: convertXFromLegacy(x),
    y: convertYFromLegacy(y),
  };
};

const convertXFromLegacy = (legacyX: number) => {
  return xSystemLocationOfLegacyOrigin + legacyX * xSystemPerLegacy;
};
const convertYFromLegacy = (legacyY: number) => {
  return ySystemLocationOfLegacyOrigin + legacyY * ySystemPerLegacy;
};


