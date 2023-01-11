import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PlayerDto, PlayerServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-player-dialog',
  templateUrl: './edit-player-dialog.component.html',
  styles: [
  ]
})
export class EditPlayerDialogComponent extends AppComponentBase
implements OnInit {
saving = false;
player = new PlayerDto();
id: number;

@Output() onSave = new EventEmitter<any>();

constructor(
  injector: Injector,
  public _playerService: PlayerServiceProxy,
  public bsModalRef: BsModalRef
) {
  super(injector);
}

ngOnInit(): void {
  this._playerService.get(this.id).subscribe((result) => {
    this.player = result;
  });
}

save(): void {
  this.saving = true;


  this._playerService.update(this.player).subscribe(
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

