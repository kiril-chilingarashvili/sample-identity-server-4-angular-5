import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
  model: FormGroup = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  loading = false;
  submitted = false;
  loginFailed = false;

  constructor(
    private router: Router,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
  }

  async login() {
    if (!this.model.valid) {
      return;
    }
    this.loginFailed = false;
    this.loading = true;

    // const success = await this.authService.login(
    //   this.model.value.username,
    //   this.model.value.password
    // );
    //
    // if (success) {
    //   await this.router.navigate(["/"]);
    // } else {
    //   this.loginFailed = true;
    //   this.loading = false;
    // }
  }
}
