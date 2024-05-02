import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from 'app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Output() canelRegister = new EventEmitter();
  model: any = {}
  constructor(private accountService:AccountService){}

  register(){
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: error => {
        console.log(error)
      }
    })

  }
  cancel(){
    this.canelRegister.emit(false);
  }
}
