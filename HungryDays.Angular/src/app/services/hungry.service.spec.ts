import { TestBed } from '@angular/core/testing';

import { HungryService } from './hungry.service';

describe('HungryService', () => {
  let service: HungryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HungryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
