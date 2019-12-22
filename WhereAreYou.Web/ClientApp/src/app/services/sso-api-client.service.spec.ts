import { TestBed } from '@angular/core/testing';

import { SsoApiClientService } from './sso-api-client.service';

describe('SsoApiClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SsoApiClientService = TestBed.get(SsoApiClientService);
    expect(service).toBeTruthy();
  });
});
