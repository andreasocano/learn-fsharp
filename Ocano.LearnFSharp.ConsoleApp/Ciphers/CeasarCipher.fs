module CeasarCipher
    let private alphabet = "abcdefghijklmnopqrstuvwxyz"
    let private whitespaceIndex = -1
    let private lengthOf input = String.length input
    let private modulo n m =
        let mm = if m > 0 then m else -m
        let remainder = n % mm
        if remainder < 0 then remainder + mm else remainder
    let private getIndex letter =
        if (letter = ' ') then whitespaceIndex
        else alphabet.IndexOf(letter:char)
    let private getLetter index =
        if (index = whitespaceIndex) then ' '
        else if (index < 0 && index > lengthOf alphabet) then ' '
        else alphabet.[index]
    let private getIndexAfterShift index shift =
        if (index = whitespaceIndex) then whitespaceIndex
        else modulo (index + shift) (lengthOf alphabet)
    let encrypt message shift =
        let messageLength = lengthOf message
        let letters = List.map (fun i -> message.[i]) [0..messageLength - 1]
        letters
        |> List.map getIndex
        |> List.map (fun c -> getIndexAfterShift c shift)
        |> List.map getLetter
        |> System.String.Concat
    let decrypt message shift =
        encrypt message -shift
