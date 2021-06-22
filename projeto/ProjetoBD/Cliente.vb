Public Class Cliente
    Private _clienteID As String
    Private _Nome As String
    Private _contacto As String
    Private _endereco As String

    Property CLienteID As String
        Get
            Return _clienteID
        End Get
        Set(ByVal value As String)
            _clienteID = value
        End Set
    End Property


    Property Nome() As String
        Get
            Nome = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Company Name field can’t be empty")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property Contacto() As String
        Get
            Contacto = _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
        End Set
    End Property

    Property Endereco() As String
        Get
            Endereco = _endereco
        End Get
        Set(ByVal value As String)
            _endereco = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _clienteID & "   " & _Nome & "   " & _contacto & "   " & _endereco
    End Function
End Class

