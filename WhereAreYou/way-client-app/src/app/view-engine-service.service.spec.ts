import { TestBed } from '@angular/core/testing';

import { ViewEngineServiceService } from './view-engine-service.service';

describe('ViewEngineServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ViewEngineServiceService = TestBed.get(ViewEngineServiceService);
    expect(service).toBeTruthy();
  });
});
