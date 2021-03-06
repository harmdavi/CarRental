﻿Option Explicit On
Option Strict On
Option Compare Binary

'David Harmon
'RCET0265
'Fall 2020
'Car Rental
'https://github.com/harmdavi/MathContestForm.git


Public Class RentalForm
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click

    End Sub

    Dim dailySummery(2, 3) As String
    Dim nameNumberError, cityNumberError, stateNumberError, zipLetterError, odomLetterErrorB, odomLetterErrorE, endOdomLetterError, odomNegativeError As String
    Dim customerRunningTotal, distanceRunningTotal, chargesRunningTotal As String
    Dim odomGreatLessError, daysGreaterError, daysLetterError, blankSpaceError As String
    Dim totalCustomers, totalDistance, totalDailyCharges As Double



    Dim summeryEnabled As Boolean



    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click, SummaryToolStripMenuItem1.Click
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

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem1.Click
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

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'This handles the evet when the exit button is pressed. There is a message box that opens and propts the user if they are sure if they want to exit. 
        Dim answer As Integer
        answer = MsgBox("Are you sure that you would like to Exit?", vbYesNo)
        If answer = vbYes Then

            Me.Close()
        Else

        End If
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click, CalculateToolStripMenuItem.Click

        'The calculate button handles a lot of functions. It calculates the values of the input values. It also handles the other critera that the assingment requires. 

        Dim errorCheckList As List(Of String)
        Dim sResult As String
        Dim blankCheck As New List(Of String)()
        Dim errorMessages As New List(Of String)()
        Dim goodData, numberCheck As Integer
        Dim fakeData, fakeDataBad, nameTrue, stateTrue, zipTrue, beginOdomTrue, endOdomTrue, cityTrue, odomBTrue, odomETrue, dayTrue As Boolean
        Dim minusDiscount, totalCharge, dailyCharge, mileCharge, milesBegin, milesDriven, milesEnd As Double
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

        fakeDataBad = False


        If fakeDataBad Then
            NameTextBox.Text = "Da12!@#$`~()><?RF"
            AddressTextBox.Text = "asASBMEOZ@#~_-?><$"
            CityTextBox.Text = "QweFM,><?!@#1231432"
            StateTextBox.Text = "DaslmeME!234865?!@`~"
            ZipCodeTextBox.Text = "FemaR1@#4$JFAm+`~"
            BeginOdometerTextBox.Text = "1293874Jmaerop3r{?>>!~`"
            EndOdometerTextBox.Text = "08w@JmfEoOInNmvm!`~?)(<><"
            DaysTextBox.Text = "203874oFlzjc~1`><?E"
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
            blankSpaceError = $"ERROR You cannot leave any of the boxes empty{vbNewLine}"
            errorMessages.Add(blankSpaceError)
            goodData += 1
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

            stateNumberError = $"ERROR You cannot have a number in the State text box{vbNewLine}"
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

            zipLetterError = $"ERROR You cannot have a letter or Character in the Zip Code text box{vbNewLine}"
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
            odomLetterErrorB = $"ERROR You cannot have a letter or Character in the Begin Odometer box{vbNewLine}"
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
            odomLetterErrorE = $"ERROR You cannot have a letter or Character in the End Odometer box{vbNewLine}"
            errorMessages.Add(odomLetterErrorE)
            EndOdometerTextBox.Clear()
            goodData += 1

        End If

        Try


            If CInt(BeginOdometerTextBox.Text) > CInt(EndOdometerTextBox.Text) Then
                odomGreatLessError = $"ERROR You cannot have the beginning Odometer number greater then the End Odometer number{vbNewLine}"
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

            daysLetterError = $"ERROR You cannot have letters or Characters in the Number of Days box{vbNewLine}"
            errorMessages.Add(daysLetterError)
            DaysTextBox.Clear()
            goodData += 1
        End If

        Try

            If CInt(DaysTextBox.Text) > 45 Or CInt(DaysTextBox.Text) < 0 Then
                daysGreaterError = $"ERROR You cannot have Days less than 0 or greater then 45 in the Number of Days box{vbNewLine}"
                errorMessages.Add(daysGreaterError)
                DaysTextBox.Clear()
                goodData += 1
            End If
        Catch ex As Exception

        End Try

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

            totalCustomers += 1
            totalDistance += milesDriven
            totalDailyCharges += totalCharge

        Else
            'This is a redundancy incase something gets super broken but it shouldnt ever work.
            MsgBox("You Broke the Calculation function")
        End If

        'This is to allow for the summery button to be enabled after the first entry.
        If totalCustomers > 0 Then
            SummaryButton.Enabled = True
        End If
        NameTextBox.Text = ""
        AddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        BeginOdometerTextBox.Text = ""
        EndOdometerTextBox.Text = ""
        DaysTextBox.Text = ""





    End Sub

    Private Sub RentalForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SummaryButton.Enabled = False
    End Sub


End Class

