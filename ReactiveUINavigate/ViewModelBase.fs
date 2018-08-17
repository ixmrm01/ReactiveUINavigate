namespace ReactiveUINavigate

open System.Reactive.Disposables

open ReactiveUI

open LocatorDefaults

type ViewModelBase(?host: IScreen) as this =
    inherit ReactiveObject()

    let pageDisposables = new CompositeDisposable()

    let hostScreen = LocateIfNone host
    let mutable urlPathSegment = Unchecked.defaultof<string>

    member __.PageDisposables
        with get() =
            pageDisposables

    member __.HostScreen
        with get() =
            hostScreen

    interface IRoutableViewModel with
        member __.HostScreen
            with get() =
                this.HostScreen

        member __.UrlPathSegment
            with get() =
                urlPathSegment
