<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class haladmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(haladmin))
        Me.btnMahasiswa = New System.Windows.Forms.Button()
        Me.btnProdi = New System.Windows.Forms.Button()
        Me.btnMat = New System.Windows.Forms.Button()
        Me.btnKembali = New System.Windows.Forms.Button()
        Me.btnKul = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMahasiswa
        '
        Me.btnMahasiswa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnMahasiswa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMahasiswa.Location = New System.Drawing.Point(114, 40)
        Me.btnMahasiswa.Name = "btnMahasiswa"
        Me.btnMahasiswa.Size = New System.Drawing.Size(138, 49)
        Me.btnMahasiswa.TabIndex = 0
        Me.btnMahasiswa.Text = "Mahasiswa"
        Me.btnMahasiswa.UseVisualStyleBackColor = False
        '
        'btnProdi
        '
        Me.btnProdi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnProdi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdi.Location = New System.Drawing.Point(114, 95)
        Me.btnProdi.Name = "btnProdi"
        Me.btnProdi.Size = New System.Drawing.Size(138, 49)
        Me.btnProdi.TabIndex = 1
        Me.btnProdi.Text = "Prodi"
        Me.btnProdi.UseVisualStyleBackColor = False
        '
        'btnMat
        '
        Me.btnMat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnMat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMat.Location = New System.Drawing.Point(114, 150)
        Me.btnMat.Name = "btnMat"
        Me.btnMat.Size = New System.Drawing.Size(138, 49)
        Me.btnMat.TabIndex = 2
        Me.btnMat.Text = "Mata Kuliah"
        Me.btnMat.UseVisualStyleBackColor = False
        '
        'btnKembali
        '
        Me.btnKembali.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnKembali.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnKembali.Location = New System.Drawing.Point(13, 13)
        Me.btnKembali.Name = "btnKembali"
        Me.btnKembali.Size = New System.Drawing.Size(75, 23)
        Me.btnKembali.TabIndex = 3
        Me.btnKembali.Text = "Kembali"
        Me.btnKembali.UseVisualStyleBackColor = False
        '
        'btnKul
        '
        Me.btnKul.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnKul.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKul.Location = New System.Drawing.Point(114, 205)
        Me.btnKul.Name = "btnKul"
        Me.btnKul.Size = New System.Drawing.Size(138, 49)
        Me.btnKul.TabIndex = 4
        Me.btnKul.Text = "Perkuliahan"
        Me.btnKul.UseVisualStyleBackColor = False
        '
        'haladmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(361, 293)
        Me.Controls.Add(Me.btnKul)
        Me.Controls.Add(Me.btnKembali)
        Me.Controls.Add(Me.btnMat)
        Me.Controls.Add(Me.btnProdi)
        Me.Controls.Add(Me.btnMahasiswa)
        Me.Name = "haladmin"
        Me.Text = "haladmin"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnMahasiswa As Button
    Friend WithEvents btnProdi As Button
    Friend WithEvents btnMat As Button
    Friend WithEvents btnKembali As Button
    Friend WithEvents btnKul As Button
End Class
