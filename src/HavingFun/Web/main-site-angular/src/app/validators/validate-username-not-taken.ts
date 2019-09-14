import { UserService } from '../services/user.service';
import { AbstractControl } from '@angular/forms';
import { map } from 'rxjs/operators';

export class ValidateUsernameNotTaken {
  static createValidator(userService: UserService) {
    return (control: AbstractControl) => {
      return userService.checkUsernameNotTaken(control.value).pipe(map(res => {
        return res ? null : { emailTaken: true };
      }));
    };
  }
}