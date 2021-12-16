import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EffectsModule, Actions } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";

import { classReducer } from './state/class.reducer';
import { ClassEffect } from './state/class.effects';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature("class", classReducer),
    EffectsModule.forFeature([ClassEffect])
  ]
})
export class ClassModule { }
