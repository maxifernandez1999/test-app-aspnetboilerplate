import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import {
  PlayerServiceProxy,
  PlayerDto,
  RoleDto
} from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-create-player-dialog',
  templateUrl: './create-player-dialog.component.html',
  styles: [
  ]
})
export class CreatePlayerDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  player = new PlayerDto();
  roles: RoleDto[] = [];
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  passwordValidationErrors: Partial<AbpValidationError>[] = [
    {
      name: 'pattern',
      localizationKey:
        'PasswordsMustBeAtLeast8CharactersContainLowercaseUppercaseNumber',
    },
  ];
  confirmPasswordValidationErrors: Partial<AbpValidationError>[] = [
    {
      name: 'validateEqual',
      localizationKey: 'PasswordsDoNotMatch',
    },
  ];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _playerService: PlayerServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void { }

  save(): void {
    this.saving = true;

    this._playerService.create(this.player).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}

