Option Explicit On
Option Strict On
Option Compare Binary

'David Harmon



Public Class RentalForm
    'These where a sad attempt on a dream lost. (basically what I thought would work did not at all)

    'Dim mrKrabs As New List(Of String)
    'Dim number() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
    'Dim letter() As String = {"q", "Q", "w", "W", "e", "E", "r", "R", "t", "T", "y", "Y", "u", "U", "i", "I", "o", "O",
    '    "p", "P", "a", "A", "s", "S", "d", "D", "f", "F", "g", "G", "h", "H", "j", "J", "k", "K", "l", "L", "z", "Z", "x", "X", "c",
    '    "C", "v", "V", "b", "B", "n", "N", "m", "M"}

    Dim errorMessages As New List(Of String)()
    Dim blankCheck As New List(Of String)()
    Dim dailySummery(2, 3) As String
    Dim nameNumberError, cityNumberError, stateNumberError, zipLetterError, odomLetterErrorB, odomLetterErrorE, endOdomLetterError, odomNegativeError As String
    Dim customerRunningTotal, distanceRunningTotal, chargesRunningTotal As String
    Dim odomGreatLessError, daysGreaterError, daysLetterError, blankSpaceError As String
    Dim totalCustomers, totalDistance, totalDailyCharges As Double


    Dim sResult As String = ""

    Dim summeryEnabled As Boolean



    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        'This performs the summery button function. This Perfoms eveything that the clear funtion does and also displays a running total of 
        'the ammount of customers that were seen that day, the total number of miles driven, and also the total amount of money made in the day
        MsgBox($"TotalNumber of Customers = {totalCustomers} {vbNewLine} Total Distance Traveled = {totalDistance} Miles {vbNewLine} Total Daily Charges = ${totalDailyCharges} ")

        NameTextBox.Text = ""
        AddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        BeginOdometerTextBox.Text = ""
        EndOdometerTextBox.Text = ""
        DaysTextBox.Text = ""
        TotalMilesTextBox.Text = ""
        MileageChargeTextBox.Text = ""
        DayChargeTextBox.Text = ""
        TotalDiscountTextBox.Text = ""
        TotalChargeTextBox.Text = ""
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'this sub handles the event when the clear button is pressed. This clears all of the fields for the resultant and user input text boxes. 
        NameTextBox.Text = ""
        AddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        BeginOdometerTextBox.Text = ""
        EndOdometerTextBox.Text = ""
        DaysTextBox.Text = ""
        TotalMilesTextBox.Text = ""
        MileageChargeTextBox.Text = ""
        DayChargeTextBox.Text = ""
        TotalDiscountTextBox.Text = ""
        TotalChargeTextBox.Text = ""


        MilesradioButton.Checked = True
    End Sub

    Private Sub MilesradioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MilesradioButton.CheckedChanged

    End Sub

    Private Sub TotalMilesTextBox_TextChanged(sender As Object, e As EventArgs) Handles TotalMilesTextBox.TextChanged

    End Sub

    Private Sub AAAcheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles AAAcheckbox.CheckedChanged

    End Sub

    Dim errorCheckList As List(Of String)


    Dim goodData, numberCheck As Integer

    Dim fakeData, nameTrue, stateTrue, zipTrue, beginOdomTrue, endOdomTrue, cityTrue, odomBTrue, odomETrue, dayTrue As Boolean



    Dim minusDiscount, totalCharge, dailyCharge, mileCharge, milesBegin, milesDriven, milesEnd As Double







    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'This handles the evet when the exit button is pressed. There is a message box that opens and propts the user if they are sure if they want to exit. 
        Dim answer As Integer
        answer = MsgBox("Are you sure that you would like to Exit?", vbYesNo)
        If answer = vbYes Then

            Me.Close()
        Else

        End If
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        'The calculate button handles a lot of functions. It calculates the values of the input values. It also handles the other critera that the assingment requires. 


        Dim textNumbers As New List(Of String)
        'These values are for default purposes. This is needed to help the logic of the program
        errorMessages.Clear()
        stateTrue = False
        zipTrue = True
        beginOdomTrue = False
        endOdomTrue = False
        nameTrue = False
        cityTrue = False
        odomBTrue = True
        odomETrue = True
        dayTrue = True


        'this is for debugging and testing the circuit. If you would like to preset some values into the boxes, just set the fakedata variable to true. Otherwise the program works as normal

        fakeData = False

        If fakeData Then
            NameTextBox.Text = "David Harmon"
            AddressTextBox.Text = "168 1/2 Charles Pl"
            CityTextBox.Text = "Pocatello"
            StateTextBox.Text = "Idaho"
            ZipCodeTextBox.Text = "83201"
            BeginOdometerTextBox.Text = "0"
            EndOdometerTextBox.Text = "1000"
            DaysTextBox.Text = "2"


        End If

        'This looks at every character in the nametextbox and converts their values into its ASCII value. This way I could filter only letting numbers or letters into 
        'the text boxes. 

        For Each thingy In NameTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                    nameTrue = True
            End Select

        Next

        If nameTrue Then
            nameNumberError = $"ERROR You cannot have a number in the Name Box {vbNewLine}"
            errorMessages.Add(nameNumberError)
            NameTextBox.Clear()
            goodData += 1
        End If
        'This was a failed attemnt at using lists and arrays to filter numbers and letters out. 

        'If NameTextBox.Text.Contains("1") Or NameTextBox.Text.Contains("2") Or NameTextBox.Text.Contains("3") Or NameTextBox.Text.Contains("4") Or NameTextBox.Text.Contains("5") Or NameTextBox.Text.Contains("6") Or NameTextBox.Text.Contains("7") Or NameTextBox.Text.Contains("8") Or NameTextBox.Text.Contains("9") Or NameTextBox.Text.Contains("0") Then

        '    nameNumberError = $"ERROR You cannot have a number in the Name Box {vbNewLine}"
        '    errorMessages.Add(nameNumberError)
        '    NameTextBox.Clear()
        '    goodData += 1

        'End If

        'If CityTextBox.Text.Contains("1") Or CityTextBox.Text.Contains("2") Or CityTextBox.Text.Contains("3") Or CityTextBox.Text.Contains("4") Or CityTextBox.Text.Contains("5") Or CityTextBox.Text.Contains("6") Or CityTextBox.Text.Contains("7") Or CityTextBox.Text.Contains("8") Or CityTextBox.Text.Contains("9") Or CityTextBox.Text.Contains("0") Then
        'End If

        For Each thingy In CityTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                    cityTrue = True
            End Select
        Next

        If cityTrue Then
            cityNumberError = $"ERROR You cannot have a number in the City text box {vbNewLine}"
            errorMessages.Add(cityNumberError)
            CityTextBox.Clear()
            goodData += 1

        End If

        For Each thingy In StateTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                    stateTrue = True
            End Select
        Next

        If stateTrue Then

            stateNumberError = $"ERROR You cannot have a number in the State text box {vbNewLine}"
            errorMessages.Add(stateNumberError)
            StateTextBox.Clear()
            goodData += 1
        End If

        For Each thingy In ZipCodeTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                Case Else
                    zipTrue = False


            End Select
        Next

        If Not zipTrue Then

            zipLetterError = $"ERROR You cannot have a letter or Character in the Zip Code text box {vbNewLine}"
            errorMessages.Add(zipLetterError)
            ZipCodeTextBox.Clear()
            goodData += 1

        End If


        For Each thingy In BeginOdometerTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                Case Else
                    odomBTrue = False
            End Select
        Next


        If Not odomBTrue Then
            odomLetterErrorB = $"ERROR You cannot have a letter or Character in the Begin Odometer box {vbNewLine}"
            errorMessages.Add(odomLetterErrorB)
            BeginOdometerTextBox.Clear()
            goodData += 1

        End If


        For Each thingy In EndOdometerTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                Case Else
                    odomETrue = False
            End Select
        Next

        If Not odomETrue Then
            odomLetterErrorE = $"ERROR You cannot have a letter or Character in the End Odometer box {vbNewLine}"
            errorMessages.Add(odomLetterErrorE)
            EndOdometerTextBox.Clear()
            goodData += 1

        End If


        'This block of code turned out not to be nessisary because the case structure took care of negative numbers since "-" is considered a character
        ''If BeginOdometerTextBox.Handle.ToInt32 < 0 Or EndOdometerTextBox.Handle.ToInt32 < 0 Then
        ''    odomNegativeError = "ERROR You cannot have a negative number in either of the Odometer boxes"
        ''    errorMessages.Add(odomNegativeError)
        ''    BeginOdometerTextBox.Clear()
        ''    EndOdometerTextBox.Clear()
        ''    goodData += 1
        ''End If
        Try


            If CInt(BeginOdometerTextBox.Text) > CInt(EndOdometerTextBox.Text) Then
                odomGreatLessError = $"ERROR You cannot have the beginning Odometer number greater then the End Odometer number {vbNewLine}"
                errorMessages.Add(odomGreatLessError)
                BeginOdometerTextBox.Clear()
                EndOdometerTextBox.Clear()
                goodData += 1
            End If

        Catch ex As Exception
        End Try

        For Each thingy In DaysTextBox.Text

            numberCheck = Asc(thingy)

            Select Case numberCheck
                Case 48 To 57
                Case Else
                    dayTrue = False
            End Select
        Next

        If Not dayTrue Then

            daysLetterError = $"ERROR You cannot have letters or Characters in the Number of Days box {vbNewLine}"
            errorMessages.Add(daysLetterError)
            DaysTextBox.Clear()
            goodData += 1
        End If

        If CInt(DaysTextBox.Text) > 45 Or CInt(DaysTextBox.Text) < 0 Then
            daysGreaterError = $"ERROR You cannot have Days less than 0 or greater then 45 in the Number of Days box {vbNewLine}"
            errorMessages.Add(daysGreaterError)
            DaysTextBox.Clear()
            goodData += 1
        End If

        blankCheck.Add(NameTextBox.Text)
        blankCheck.Add(AddressTextBox.Text)
        blankCheck.Add(CityTextBox.Text)
        blankCheck.Add(StateTextBox.Text)
        blankCheck.Add(ZipCodeTextBox.Text)
        blankCheck.Add(BeginOdometerTextBox.Text)
        blankCheck.Add(EndOdometerTextBox.Text)
        blankCheck.Add(DaysTextBox.Text)

        If blankCheck.Contains("") Then
            blankSpaceError = $"ERROR You cannot leave any of the boxes empty {vbNewLine}"
            errorMessages.Add(blankSpaceError)
            goodData += 1
        End If

        'This portion is something that I found online that allows for the contents of my list to be displayed in a msgbox.
        'https://stackoverflow.com/questions/16054054/display-content-of-the-array-list

        For Each elem As String In errorMessages
            sResult &= elem & ""
        Next

        'If any of the error conditions above get triggered, goodData will not equal 0. this will display all of the errors and the 
        'clearing of incorrect data will have already happened. 
        If goodData <> 0 Then
            MsgBox(sResult)
            errorMessages.Clear()
            sResult = ""


        ElseIf goodData = 0 Then
            'This is where the calculating will happen
            dailyCharge = CInt(DaysTextBox.Text) * 15

            If MilesradioButton.Checked Then
                milesBegin = CDec(BeginOdometerTextBox.Text)
                milesEnd = CDec(EndOdometerTextBox.Text)
            End If

            If KilometersradioButton.Checked Then
                milesBegin = CDec(BeginOdometerTextBox.Text) * 0.62
                milesEnd = CDec(EndOdometerTextBox.Text) * 0.62
            End If

            milesDriven = milesEnd - milesBegin

            Select Case milesDriven
                Case 0 - 200
                    mileCharge = 0
                Case 201 - 500
                    mileCharge = (milesDriven - 200) * 0.12
                Case Else
                    mileCharge = 35.88 + ((milesDriven - 500) * 0.1)

            End Select


            If AAAcheckbox.Checked And Seniorcheckbox.Checked Then

                totalCharge = (mileCharge + dailyCharge) * 0.92
            ElseIf AAAcheckbox.Checked And Not Seniorcheckbox.Checked Then
                totalCharge = (mileCharge + dailyCharge) * 0.95
            ElseIf Not AAAcheckbox.Checked And Seniorcheckbox.Checked Then
                totalCharge = (mileCharge + dailyCharge) * 0.97
            ElseIf Not AAAcheckbox.Checked And Not Seniorcheckbox.Checked Then
                totalCharge = mileCharge + dailyCharge
            End If


            minusDiscount = (mileCharge + dailyCharge) - totalCharge

            TotalMilesTextBox.Text = $"{milesDriven} Miles"
            MileageChargeTextBox.Text = FormatCurrency($"${mileCharge}",,, TriState.True, TriState.True)
            DayChargeTextBox.Text = FormatCurrency($"${dailyCharge}",,, TriState.True, TriState.True)
            TotalDiscountTextBox.Text = FormatCurrency($"${minusDiscount}",,, TriState.True, TriState.True)
            TotalChargeTextBox.Text = FormatCurrency($"${totalCharge}",,, TriState.True, TriState.True)

            'If milesDriven < 200 Then
            '    mileCharge = 90
            'End If

            'If milesDriven < 201 And milesDriven > 500 Then
            'End If

            'If milesDriven > 501 Then

            'End If


            'MsgBox($"miles Driven = {milesDriven} {vbNewLine} Mile Charge = {mileCharge} {vbNewLine} Daily Charge = {dailyCharge}")

            totalCustomers += 1
            totalDistance += milesDriven
            totalDailyCharges += totalCharge


            'This was an attempt to make the summery button code simplier but it actually made it harder. I found a less eligant way to get the job done. 

            'dailySummery(1, 1) = "Total Number of Consumers Today = "
            'dailySummery(1, 2) = "Total Distance Driven Today = "
            'dailySummery(1, 3) = "Total Charges Today = "

            'dailySummery(2, 1) = $"{totalCustomers}"
            'dailySummery(2, 2) = $"{totalDistance}"
            'dailySummery(2, 3) = $"{totalDailyCharges}"

        Else
            'This is a redundancy incase something gets super broken but it shouldnt ever work.
            MsgBox("You Broke the Calculation function")
        End If

        'This is to allow for the summery button to be enabled after the first entry.
        If totalCustomers > 0 Then
            SummaryButton.Enabled = True
        End If
    End Sub

    Private Sub EvaluateTextBoxes()



    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged

    End Sub

    Private Sub ZipCodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ZipCodeTextBox.TextChanged

    End Sub

    Private Sub DaysTextBox_TextChanged(sender As Object, e As EventArgs) Handles DaysTextBox.TextChanged

    End Sub

    Private Sub RentalForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SummaryButton.Enabled = False
    End Sub

    'Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    '    Throw New NotImplementedException()
    'End Function
End Class
