import { TestBed } from '@angular/core/testing';
import {TripsApiService} from "./trips-api.service";

describe('TripsApiService', () => {
  let service: TripsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TripsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
