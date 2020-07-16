import { TestBed } from '@angular/core/testing';

import { SecondarySellerService } from './secondary-seller.service';

describe('SecondarySellerService', () => {
  let service: SecondarySellerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecondarySellerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
