namespace ReactiveUINavigate

open Xamarin.Forms.Xaml

type SecondPage() =
    inherit ContentPageBase<SecondViewModel>()

    let _ = base.LoadFromXaml(typeof<SecondPage>)
