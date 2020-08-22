import { Injectable } from '@angular/core';
import { EnterTheMeet } from '../models/enter-the-meet';

@Injectable({
  providedIn: 'root'
})

export class StateService {
  public enterTheMeet: EnterTheMeet = new EnterTheMeet();

  constructor() {
  }
}
