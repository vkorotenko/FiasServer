export class CityItem implements CityItemInterface {
    id: number;
    regionId: number;
    name: string;
    lon: number;
    lat: number;
    slug: string;
    prefix: string;
    guid: string;
    parent: string;
    constructor () {
      this.id = 0
      this.regionId = 0
      this.name = ''
      this.lon = 0
      this.lat = 0
      this.slug = ''
      this.prefix = ''
      this.guid = ''
      this.parent = ''
    }
}

export interface CityItemInterface {
    id: number;
    regionId: number;
    name: string;
    lon: number;
    lat: number;
    slug: string;
    prefix: string;
    guid: string;
    parent: string;
}
