namespace ReactiveUINavigate

open System.Reactive.Disposables

open Xamarin.Forms

open ReactiveUI

type ContentPageBase<'TViewModel when 'TViewModel :> ReactiveObject and 'TViewModel : not struct>() as this =
    inherit ContentPage()

    let pageDisposables = new CompositeDisposable()

    let mutable viewModel = Unchecked.defaultof<'TViewModel>

    override this.OnDisappearing() =
        base.OnDisappearing()

        pageDisposables.Clear()

    member __.PageDisposables
        with get() =
            pageDisposables

    member __.ViewModel
        with get() =
            viewModel
        and set(value: 'TViewModel) =
            viewModel <- value

    interface IViewFor<'TViewModel> with
        member __.ViewModel
            with get() =
                this.ViewModel
            and set(value) =
                this.ViewModel <- value

    interface IViewFor with
        member __.ViewModel
            with get() =
                (this :> IViewFor<'TViewModel>).ViewModel :> obj
            and set(value: obj) =
                (this :> IViewFor<'TViewModel>).ViewModel <- (value :?> 'TViewModel)
