import { TestBed } from '@angular/core/testing';

import { MeetApiClientService } from './meet-api-client.service';

describe('MeetApiClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MeetApiClientService = TestBed.get(MeetApiClientService);
    expect(service).toBeTruthy();
  });
});
