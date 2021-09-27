import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { MoneyAccount } from '../_models/moneyAccount';
import { User } from '../_models/user';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  user: User;
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  addMoneyAccount(model: any) {
    return this.http.post(this.baseUrl + 'users/add-account', model).subscribe(r => { });
  }

  getMoneyAccounts() {
    return this.http.get<MoneyAccount[]>(this.baseUrl + 'users/accounts');
  }
}
