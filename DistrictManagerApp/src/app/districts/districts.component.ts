import { Component, OnInit } from '@angular/core';

import { District } from './district';
import { DistrictsService } from './districts.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-districts',
  templateUrl: './districts.component.html',
  providers: [DistrictsService],
  styleUrls: ['./districts.component.css']
})
export class DistrictsComponent implements OnInit {
  districts: District[];
  focusDistrict: District;

  constructor(private districtsService: DistrictsService,
              private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllDistricts();
  }

  getAllDistricts(): void {
    this.districtsService.getAllDistricts()
      .subscribe(districts => (this.districts = districts));
  }

  delete(district: District): void {
    this.districts = this.districts.filter(d => d !== district);
    this.districtsService.deleteDistrict(district.districtId).subscribe();
  }
}
