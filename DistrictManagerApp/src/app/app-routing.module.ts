import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DistrictsComponent } from './districts/districts.component';
import { DistrictDetailComponent } from './district-detail/district-detail.component';
import { AddDataComponent } from './add-data/add-data.component';

const routes: Routes = [
  { path: 'districts', component: DistrictsComponent},
  { path: 'districts/:id', component: DistrictDetailComponent },
  { path: 'add', component: AddDataComponent },
  { path: '', redirectTo: '/districts', pathMatch: 'full'}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
