import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { DistrictsService } from '../Services/districts.service';
import { District } from '../Models/district';
import { Seller } from '../Models/seller';
import { SecondarySeller } from '../Models/secondarySeller'
import { SellerService } from '../Services/seller.service';
import { SecondarySellerService } from '../Services/secondary-seller.service';
import {Store} from '../Models/store';
import {StoreService} from '../Services/store.service';


@Component({
  selector: 'app-district-detail',
  templateUrl: './district-detail.component.html',
  styleUrls: ['./district-detail.component.css']
})

export class DistrictDetailComponent implements OnInit {
  @Input() district: District;
  @Input() seller: Seller;
  secondarySellers: Seller[] = [];
  stores: Store[];
  sellers: Seller[];
  selectedSeller: number;


  constructor(
    private route: ActivatedRoute,
    private districtsService: DistrictsService,
    private sellerService: SellerService,
    private storeService: StoreService,
    private secondarySellerService: SecondarySellerService
  ) { }

  ngOnInit(): void {
    this.GetObjectsById();
    this.getAllSellers();
  }

  private GetObjectsById() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.districtsService.getDistrictById(id)
      .subscribe(district => {this.district = district;
      this.sellerService.getSellerById(district.sellerId).subscribe(seller => this.seller = seller)});
    this.getAllSellersForDistrict(id);
    this.getStoresByDistrictId(id);
  }

  private getAllSellersForDistrict(districtId: number) {
    this.secondarySellerService.getSecondarySellersByDistrictId(districtId)
      .subscribe(secondarySellers => secondarySellers.forEach
      ((value, index) => this.getSeller(secondarySellers[index].sellerId)))
  }

  private getSeller(sellerId: number): void {
    this.sellerService.getSellerById(sellerId)
      .subscribe(secondarySeller => this.secondarySellers.push(secondarySeller));
  }

  private getStoresByDistrictId(districtId: number) {
    this.storeService.getStoresByDistrictId(districtId)
      .subscribe(stores => this.stores = stores);
  }

  private deleteSecondarySeller(seller: Seller, districtId: number): void {
    this.secondarySellers = this.secondarySellers.filter(d => d !== seller);
    this.secondarySellerService.deleteSecondarySeller(seller.sellerId, districtId).subscribe();
  }

  private getAllSellers(): void {
    this.sellerService.getAllSellers()
      .subscribe(sellers => (this.sellers = sellers));
  }

  private createSecondarySeller(sellerId: number, districtId: number): void {
    const newSecondarySeller: SecondarySeller = {sellerId, districtId} as SecondarySeller;
    console.log(this.secondarySellerService);
    this.secondarySellerService.addSecondarySeller(newSecondarySeller)
      .subscribe(secondarySeller => this.getSeller(secondarySeller.sellerId));
  }
}
