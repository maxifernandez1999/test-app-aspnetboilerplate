import { Component, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { PlayerDto, PlayerDtoPagedResultDto, PlayerServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreatePlayerDialogComponent } from './create-player/create-player-dialog.component';
import { EditPlayerDialogComponent } from './edit-player/edit-player-dialog.component';
class PagedPlayersRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  animations: [appModuleAnimation()],
  styleUrls: [

  ]
})
export class PlayerComponent extends PagedListingComponentBase<PlayerDto> {
  players: PlayerDto[] = [];
  public keyword = '';
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _playerService: PlayerServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createPlayer(): void {
    this.showCreateOrEditPlayerDialog();
  }

  editPlayer(player: PlayerDto): void {
    this.showCreateOrEditPlayerDialog(player.id);
  }

  // public resetPassword(user: PlayerDto): void {
  //   this.showResetPasswordUserDialog(user.id);
  // }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }

  protected list(
    request: PagedPlayersRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._playerService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: PlayerDtoPagedResultDto) => {
        this.players = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(player: PlayerDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', player.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._playerService.delete(player.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  // private showResetPasswordUserDialog(id?: number): void {
  //   this._modalService.show(ResetPasswordDialogComponent, {
  //     class: 'modal-lg',
  //     initialState: {
  //       id: id,
  //     },
  //   });
  // }

  private showCreateOrEditPlayerDialog(id?: number): void {
    let createOrEditPlayerDialog: BsModalRef;
    if (!id) {
      createOrEditPlayerDialog = this._modalService.show(
        CreatePlayerDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditPlayerDialog = this._modalService.show(
        EditPlayerDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id
          },
        }
      );
    }

    createOrEditPlayerDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
