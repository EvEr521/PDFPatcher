﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PDFPatcher.Common;

namespace PDFPatcher.Functions
{
	public partial class FontCharSubstitutionForm : Form
	{
		readonly FontSubstitution _Substitution;

		public FontCharSubstitutionForm(FontSubstitution substitution) {
			InitializeComponent();
			this.SetIcon(Properties.Resources.Replace);
			MinimumSize = Size;
			MaximumSize = new Size(999, Size.Height);
			_Substitution = substitution;
			_OriginalCharactersBox.Text = substitution.OriginalCharacters;
			_SubstituteCharactersBox.Text = substitution.SubstituteCharacters;
			_ChineseCaseBox.Select(substitution.TraditionalChineseConversion == -1 ? 2 : substitution.TraditionalChineseConversion);
		}

		void _OriginalCharactersBox_TextChanged(object sender, EventArgs e) {
			_Substitution.OriginalCharacters = _OriginalCharactersBox.Text;
		}

		void _SubstituteCharactersBox_TextChanged(object sender, EventArgs e) {
			_Substitution.SubstituteCharacters = _SubstituteCharactersBox.Text;
		}

		void _SubstituteCharactersBox_Enter(object sender, EventArgs e) {
			_SubstituteCharactersBox.Select(
				_OriginalCharactersBox.SelectionStart,
				_OriginalCharactersBox.SelectionLength
			);
		}

		void _OriginalCharactersBox_SelectionChanged(object sender, EventArgs e) {
			_SubstituteCharactersBox.Select(
				_OriginalCharactersBox.SelectionStart,
				_OriginalCharactersBox.SelectionLength
			);
		}

		void _ChineseCaseBox_SelectedIndexChanged(object sender, EventArgs e) {
			_Substitution.TraditionalChineseConversion = _ChineseCaseBox.SelectedIndex == 2 ? -1 : _ChineseCaseBox.SelectedIndex;
		}
	}
}
