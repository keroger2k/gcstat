import { Team } from '@state/modules';

/*
    This calculation is needed because Eden Spraychart coords are based on the original iPhone
    It takes the coordinates of homeplate and first base and determines the ratios for x and y
    coordinates to remap the original aspect ratio and coords to our systems.  Since we use an
    SVG the coordinates will be correct regardless the size that's actually displayed.
*/

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

type SprayChartHit = Coords & {
  key: string;
  type: string;
};

type HomeRunCounter = {
  left: number;
  center: number;
  right: number;
};

export type SprayChartHitObject = {
  hits: SprayChartHit[];
  homeRuns: HomeRunCounter;
};

export const processSprayChartData = (sprayChartData: Team.SprayChartData[]): SprayChartHitObject => {
  const scData: SprayChartHitObject = {
    hits: [],
    homeRuns: {
      left: 0,
      right: 0,
      center: 0,
    },
  };
  const outList: SprayChartHit[] = [];
  const hitList: SprayChartHit[] = [];
  sprayChartData.forEach((data) => {
    if (data.hrLocation && data.hrLocation !== 'in_the_park') {
      switch (data.hrLocation) {
        case Team.HomeRunLocation.RIGHT_FIELD:
          scData.homeRuns.right += 1;
          break;
        case Team.HomeRunLocation.CENTER_FIELD:
          scData.homeRuns.center += 1;
          break;
        case Team.HomeRunLocation.LEFT_FIELD:
          scData.homeRuns.left += 1;
          break;
      }
    } else {
      const { x, y }: Coords = convertFromLegacy(data.location);
      const hitData = { x: x, y: y, key: data.id, type: data.playResult };

      if (hitData.type === 'hit') {
        hitList.push(hitData);
      } else {
        outList.push(hitData);
      }
    }
  });
  scData.hits = [...outList, ...hitList];
  return scData;
};

const convertXFromLegacy = (legacyX: number) => {
  return xSystemLocationOfLegacyOrigin + legacyX * xSystemPerLegacy;
};
const convertYFromLegacy = (legacyY: number) => {
  return ySystemLocationOfLegacyOrigin + legacyY * ySystemPerLegacy;
};
