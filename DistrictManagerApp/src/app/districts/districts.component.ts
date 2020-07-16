import { Component, OnInit } from '@angular/core';

import { District } from '../Models/district';
import { DistrictsService } from '../Services/districts.service';


@Component({
  selector: 'app-districts',
  templateUrl: './districts.component.html',
  providers: [DistrictsService],
  styleUrls: ['./districts.component.css']
})
export class DistrictsComponent implements OnInit {
  districts: District[];
  focusDistrict: District;

  constructor(private districtsService: DistrictsService) { }

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

  createDistrict(districtName: string, sellerId: number): void{
    districtName = districtName.trim();
    if (!districtName){
      return;
    }

    const newDistrict: District = {districtName, sellerId} as District;
    this.districtsService.addDistrict(newDistrict).subscribe(district => this.districts.push(district))
  }

  focus(district: District) {
    this.focusDistrict = district;
  }
}
