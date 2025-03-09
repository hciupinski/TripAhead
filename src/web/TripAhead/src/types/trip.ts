export enum TripState {
  DRAFT = 'DRAFT',
  ACTIVE = 'ACTIVE',
  FINISHED = 'FINISHED'
}

export interface Trip {
  id: string;
  name: string;
  occupancy: number;
  cost: number;
  state: TripState;
  destination: string;
  startDate: string;
  endDate: string;
  page: string;
}

export type TripsResponse = {
  trips: Trip[];
}

export type TripResponse = {
  trip: Trip;
}
