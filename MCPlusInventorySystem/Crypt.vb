Imports System.Text

Module Crypt
    Private key As String = "Q$t1tchCryptKey12345678901212345" ' 32-byte key for AES-256 (needs to be 32 char)
    Private iv As String = "Q$t1tchCrypt4321" ' 16-byte IV for AES (needs to be 16 char)
    Public Function EncryptString(ByVal inputString As String) As String
        Using aesAlg As Security.Cryptography.Aes = Security.Cryptography.Aes.Create()

            Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(key)
            Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(iv)
            Dim keyBase64 As String = Convert.ToBase64String(keyBytes)
            Dim ivBase64 As String = Convert.ToBase64String(ivBytes)

            aesAlg.Key = Convert.FromBase64String(keyBase64)
            aesAlg.IV = Convert.FromBase64String(ivBase64)

            Dim encryptor As Security.Cryptography.ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

            Using msEncrypt As New IO.MemoryStream()
                Using csEncrypt As New Security.Cryptography.CryptoStream(msEncrypt, encryptor, Security.Cryptography.CryptoStreamMode.Write)
                    Using swEncrypt As New IO.StreamWriter(csEncrypt)
                        swEncrypt.Write(inputString)
                    End Using
                End Using

                Dim encryptedBytes As Byte() = msEncrypt.ToArray()
                Dim encryptedString As String = Convert.ToBase64String(encryptedBytes)
                Return encryptedString
            End Using
        End Using

    End Function

    Public Function DecryptString(ByVal encryptedString As String) As String
        Using aesAlg As Security.Cryptography.Aes = Security.Cryptography.Aes.Create()
            Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(key)
            Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(iv)

            Dim keyBase64 As String = Convert.ToBase64String(keyBytes)
            Dim ivBase64 As String = Convert.ToBase64String(ivBytes)

            aesAlg.Key = Convert.FromBase64String(keyBase64)
            aesAlg.IV = Convert.FromBase64String(ivBase64)

            Dim decryptor As Security.Cryptography.ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
            Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedString)

            Using msDecrypt As New IO.MemoryStream(encryptedBytes)
                Using csDecrypt As New Security.Cryptography.CryptoStream(msDecrypt, decryptor, Security.Cryptography.CryptoStreamMode.Read)
                    Using srDecrypt As New IO.StreamReader(csDecrypt)
                        Dim decryptedString As String = srDecrypt.ReadToEnd()
                        Return decryptedString
                    End Using
                End Using
            End Using
        End Using

    End Function
End Module
