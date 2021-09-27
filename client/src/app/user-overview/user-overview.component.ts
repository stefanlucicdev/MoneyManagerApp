import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AddMoneyAccountComponent } from '../modals/add-money-account/add-money-account.component';
import { MoneyAccount } from '../_models/moneyAccount';
import { User } from '../_models/user';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-user-overview',
  templateUrl: './user-overview.component.html',
  styleUrls: ['./user-overview.component.css']
})
export class UserOverviewComponent implements OnInit {
  bsModalRef: BsModalRef;
  moneyAccount: MoneyAccount;
  user: User;
  accounts: MoneyAccount[];

  constructor(private modalService: BsModalService, private memberService: MembersService) { }

  ngOnInit(): void {
    this.getMoneyAccounts();
  }

  openAddMoneyAccountModal(user: User) {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
      }
    }
    this.bsModalRef = this.modalService.show(AddMoneyAccountComponent, config);
  }

  getMoneyAccounts() {
    return this.memberService.getMoneyAccounts().subscribe(response => {
      this.accounts = response;
    })
  }
}
