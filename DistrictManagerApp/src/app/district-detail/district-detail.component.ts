import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { DistrictsService } from '../Services/districts.service';
import { District } from '../Models/district';
import { Seller } from '../Models/seller';
import { SellerService } from '../Services/seller.service';


@Component({
  selector: 'app-district-detail',
  templateUrl: './district-detail.component.html',
  styleUrls: ['./district-detail.component.css']
})

export class DistrictDetailComponent implements OnInit {
  @Input() district: District;
  @Input() seller: Seller;

  constructor(
    private route: ActivatedRoute,
    private districtsService: DistrictsService,
    private sellerService: SellerService,
  ) { }

  ngOnInit(): void {
    this.GetObjectsById();
  }

  private GetObjectsById() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.districtsService.getDistrictById(id)
      .subscribe(district => {this.district = district;
      this.sellerService.getSellerById(district.sellerId).subscribe(seller => this.seller =seller)})
  }
/*
   private async GetSellerById() {
    const id = this.district.sellerId;
    this.sellerService.getSellerById(id).subscribe(seller => this.seller = seller)
  }
  async GetAllData(){
    await this.GetDistrictById();
    await this.GetSellerById();
  }*/
}
