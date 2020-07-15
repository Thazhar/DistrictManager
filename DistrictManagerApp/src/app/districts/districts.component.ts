import { Component, OnInit } from '@angular/core';

import { District } from './district';
import { DistrictsService } from './districts.service';

@Component({
  selector: 'app-districts',
  templateUrl: './districts.component.html',
  providers: [DistrictsService],
  styleUrls: ['./districts.component.css']
})
export class DistrictsComponent implements OnInit {
  districts: District[];

  constructor(private districtsService: DistrictsService) { }

  ngOnInit(): void {
    this.getAllDistricts();
  }

  getAllDistricts(): void {
    this.districtsService.getAllDistricts()
      .subscribe(districts => (this.districts = districts));
  }
}
