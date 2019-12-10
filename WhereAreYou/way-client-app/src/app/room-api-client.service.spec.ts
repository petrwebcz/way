import { TestBed } from '@angular/core/testing';

import { RoomApiClientService } from './room-api-client.service';

describe('RoomApiClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RoomApiClientService = TestBed.get(RoomApiClientService);
    expect(service).toBeTruthy();
  });
});
