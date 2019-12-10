import { TestBed } from '@angular/core/testing';

import { SsoApiService } from './sso-api.service';

describe('SsoApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SsoApiService = TestBed.get(SsoApiService);
    expect(service).toBeTruthy();
  });
});
