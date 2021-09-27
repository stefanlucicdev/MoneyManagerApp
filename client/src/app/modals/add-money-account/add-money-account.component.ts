import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ReactiveFormsModule } from '@angular/forms';
import { MembersService } from '../../_services/members.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-money-account',
  templateUrl: './add-money-account.component.html',
  styleUrls: ['./add-money-account.component.css']
})
export class AddMoneyAccountComponent implements OnInit {
  addMoneyAccountForm: any;
  result: boolean;

  constructor(public bsModalRef: BsModalRef, private fb: FormBuilder, private memberService: MembersService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  confirm() {
    this.memberService.addMoneyAccount(this.addMoneyAccountForm.value);
    console.log(this.addMoneyAccountForm.value);
    this.result = true;
    this.bsModalRef.hide();
    this.toastr.success("New money account added successfully.");
  }

  decline() {
    this.result = false;
    this.bsModalRef.hide();
  }

  
  initializeForm() {
    this.addMoneyAccountForm = this.fb.group({
      name: ['New Account'],
      excludeFromTotal: false,
      currency: 'USD',
      initialBalance: ['0']
    })
  }
  
}

