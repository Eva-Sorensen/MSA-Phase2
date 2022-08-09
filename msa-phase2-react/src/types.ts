import { LatLngExpression } from "leaflet";

export interface CountryData {
  flags: FlagData;
  continents: string[];
  capital: string[];
  population: number;
  latlng: LatLngExpression;
  name: NameData;
  maps: MapData;
}

interface FlagData {
  png: string;
  svg: string;
}

interface NameData {
  common: string;
  official: string;
}

interface MapData {
  googleMaps: string;
  openStreetMaps: string;
}
