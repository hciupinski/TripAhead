export interface Trip {
  id: string;
  name: string;
}

export type TripsResponse = {
  trips: Trip[];
}
