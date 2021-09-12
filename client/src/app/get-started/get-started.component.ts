import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-get-started',
  templateUrl: './get-started.component.html',
  styleUrls: ['./get-started.component.css']
})
export class GetStartedComponent implements OnInit {
  model: any = {};
  maxDate: Date;
  validationErrors: string[] = [];
  registerForm: any;

  constructor(private router: Router, public accountService: AccountService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 10);
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('user/overview');
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      gender: ['male'],
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]]
    })
      this.registerForm.controls.password.valueChanges.subscribe(() => {
        this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: any) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : { isMatching: true }
    }
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('user/overview');
    }, error => {
      this.validationErrors = error;
    })
  }
}
