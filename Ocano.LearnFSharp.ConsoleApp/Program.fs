open System

[<EntryPoint>]
let main args =
    if args.Length <= 0
    then
        printfn "Please add number by which to shift the alphabet"
    else
        let shift = args.[0] |> int
        let originalMessage = "attack at dawn"
        printfn $"Original message: '{originalMessage}'"
        let cipher = CeasarCipher.encrypt originalMessage shift
        printfn $"Cipher: '{cipher}'"
        let message = CeasarCipher.decrypt cipher shift
        printfn $"Decrypted message: '{message}'"
    0