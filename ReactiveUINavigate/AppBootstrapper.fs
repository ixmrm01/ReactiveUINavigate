namespace ReactiveUINavigate

open Xamarin.Forms

open ReactiveUI
open ReactiveUI.XamForms

open Splat

type AppBootstrapper() as this =
    inherit ReactiveObject()

    let router = new RoutingState()

    do
        // IScreen
        Locator.CurrentMutable.RegisterConstant(this, typeof<IScreen>)

        // Services

        // Views and ViewModels
        Locator.CurrentMutable.Register((fun () -> new MainPage() :> obj), typeof<IViewFor<MainViewModel>>)
        Locator.CurrentMutable.Register((fun () -> new SecondPage() :> obj), typeof<IViewFor<SecondViewModel>>)

        // Routing
        router.NavigateAndReset.Execute(new MainViewModel()) |> ignore

    member __.CreateMainPage() =
        new RoutedViewHost() :> Page

    interface IScreen with
        member __.Router
            with get() =
                router
