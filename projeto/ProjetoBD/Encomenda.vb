Public Class Encomenda
    Private _ID As String
    Private _CliNome As String
    Private _prodNome As String
    Private _quant As String
    Private _price As String
    Private _date As String

    Property ID As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property


    Property CliNome() As String
        Get
            CliNome = _CliNome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Company Name field can’t be empty")
                Exit Property
            End If
            _CliNome = value
        End Set
    End Property

    Property prodNome() As String
        Get
            prodNome = _prodNome
        End Get
        Set(ByVal value As String)
            _prodNome = value
        End Set
    End Property

    Property quant() As String
        Get
            quant = _quant
        End Get
        Set(ByVal value As String)
            _quant = value
        End Set
    End Property

    Property price() As String
        Get
            price = _price
        End Get
        Set(ByVal value As String)
            _price = value
        End Set
    End Property

    Property data() As String
        Get
            data = _date
        End Get
        Set(ByVal value As String)
            _date = value
        End Set
    End Property



    Overrides Function ToString() As String
        Return _ID + Chr(9) + _CliNome + Chr(9) + _prodNome + Chr(9) + _quant + Chr(9) + _price + Chr(9) + _date
    End Function
End Class

