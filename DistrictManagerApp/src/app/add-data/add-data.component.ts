import {Component, OnInit, ViewChild} from '@angular/core';

import { District } from '../Models/district';
import { DistrictsService } from '../Services/districts.service';
import { SellerService } from '../Services/seller.service';
import { Seller } from '../Models/seller';
import {DistrictsComponent} from '../districts/districts.component';
import {StoreService} from '../Services/store.service';
import {Store} from '../Models/store';


@Component({
  selector: 'app-add-data',
  templateUrl: './add-data.component.html',
  providers: [DistrictsService],
  styleUrls: ['./add-data.component.css']
})
export class AddDataComponent implements OnInit {
  districts: District[];
  sellers: Seller[];
  stores: Store[];
  selectedSeller: number;
  selectedDistrict: number;


  constructor(private districtsService: DistrictsService,
              private sellerService: SellerService,
              private storeService: StoreService) { }

  ngOnInit(): void {
    this.getAllDistricts();
    this.getAllSellers();
    this.getAllStores();
  }

  getAllDistricts(): void {
    this.districtsService.getAllDistricts()
      .subscribe(districts => (this.districts = districts));
  }

  getAllSellers(): void {
    this.sellerService.getAllSellers()
      .subscribe(sellers => (this.sellers = sellers));
  }

  getAllStores(): void {
    this.storeService.getAllStores()
      .subscribe(stores => (this.stores = stores))
  }

  createDistrict(districtName: string, sellerId: number): void{
    districtName = districtName.trim();
    if (!districtName){
      return;
    }

    const newDistrict: District = {districtName, sellerId} as District;
    this.districtsService.addDistrict(newDistrict)
      .subscribe(district => this.districts.push(district))
  }

  createSeller(sellerName: string) {
    sellerName = sellerName.trim();
    if (!sellerName){
      return;
    }

    const newSeller: Seller = {sellerName} as Seller;
    this.sellerService.addSeller(newSeller)
      .subscribe(seller => this.sellers.push(seller))
  }

  createStore(storeName: string, districtId: number) {
    storeName = storeName.trim();
    if (!storeName){
      return;
    }

    const newStore: Store = {storeName, districtId} as Store;
    this.storeService.addStore(newStore)
      .subscribe(store => this.stores.push(store))
  }
}

