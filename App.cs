/*
 * ID: 11939
 * Auhtor: Fahad Zia
 * Section: B
 */

using LibraryCMS.Controller;
using LibraryCMS.Models;

namespace LibraryCMS
{
    public partial class App : Form
    {
        private List<Dictionary<string, string>> _authors = new();
        private List<Dictionary<string, string>> _publishers = new();
        private List<Dictionary<string, string>> _members = new();
        private List<Dictionary<string, string>> _books = new();
        public App()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            loadDataForMemberAndBooksField();
            loadDataForAuthorPublisherFields();
        }

        private void book_TabPageClick(object sender, EventArgs e)
        {
            loadDataForAuthorPublisherFields();
        }

        private void loadDataForMemberAndBooksField()
        {
            BookIssueController<BookIssue> bookIssueController = new BookIssueController<BookIssue>();
            _members = bookIssueController.GetMemberRecord()!;

            foreach (var member in _members)
            {
                foreach (var item in member)
                {
                    listBox2.Items.Add(item.Value);
                }
            }

            _books = bookIssueController.GetBookRecord()!;

            foreach (var book in _books)
            {
                foreach (var item in book)
                {
                    listBox3.Items.Add(item.Value);
                }
            }
        }

        private void loadDataForAuthorPublisherFields()
        {
            BookController<Book> bookController = new BookController<Book>();
            _authors = bookController.getAuthorRecord()!;

            foreach (var author in _authors)
            {
                foreach (var item in author)
                {
                    bookAuthorField.Items.Add(item.Value);
                }
            }

            _publishers = bookController.getPublisherRecord()!;

            foreach (var publisher in _publishers)
            {
                foreach (var item in publisher)
                {
                    bookPublisherField.Items.Add(item.Value);
                }
            }
        }

        private void click_TabPage5(object sender, EventArgs e)
        {
            loadDataForMemberAndBooksField();
        }

        private void button3_onClick(object sender, EventArgs e)
        {
            try
            {
                string authorId = "";
                foreach (var author in _authors)
                {
                    foreach (var i in author)
                    {
                        if (i.Value.ToString() == bookAuthorField.Items[bookAuthorField.SelectedIndex].ToString())
                        {
                            authorId = i.Key;
                        }
                    }
                }

                string pubId = "";
                foreach (var publisher in _publishers)
                {
                    foreach (var i in publisher)
                    {
                        if (i.Value.ToString() == bookPublisherField.Items[bookPublisherField.SelectedIndex].ToString())
                        {
                            pubId = i.Key;
                        }
                    }
                }


                new BookController<Book>().AddRecord(
                    new Book(
                        bookTitleField.Text,
                        bookPriceField.Text,
                        authorId,
                        pubId
                    ));

                clearFields();
                ShowSuccessfulMessageBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowSuccessfulMessageBox()
        {
            MessageBox.Show("Operation successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void submit_PublisherBtn(object sender, EventArgs e)
        {
            try
            {
                new PublisherController<Publisher>().AddRecord(
                    new Publisher(
                        publisherNameField.Text,
                        publisherAddressField.Text
                    ));
                clearFields();
                ShowSuccessfulMessageBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void click_MemberBtn(object sender, EventArgs e)
        {
            try
            {
                new MemberController<Member>().AddRecord(
                    new Member(
                        memberNameField.Text,
                        memberAddressField.Text
                    ));
                clearFields();
                ShowSuccessfulMessageBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                new AuthorController<Author>().AddRecord(
                    new Author(
                        nameField.Text,
                        int.Parse(ageField.Text),
                        maleRadioButton.Checked ? "Male" : "Female",
                        emailField.Text,
                        contactField.Text,
                        bioField.Text
                    ));
                clearFields();
                ShowSuccessfulMessageBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void click_BookIssueBtn(object sender, EventArgs e)
        {
            try
            {
                string memberId = "";
                foreach (var member in _members)
                {
                    foreach (var i in member)
                    {
                        if (i.Value.ToString() == listBox2.Items[listBox2.SelectedIndex].ToString())
                        {
                            memberId = i.Key;
                        }
                    }
                }

                string bookId = "";
                foreach (var book in _books)
                {
                    foreach (var i in book)
                    {
                        if (i.Value.ToString() == listBox3.Items[listBox3.SelectedIndex].ToString())
                        {
                            bookId = i.Key;
                        }
                    }
                }
                new BookIssueController<BookIssue>().AddRecord(
                    new BookIssue(
                        bookId,
                        memberId,
                        dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm")
                    ));
                clearFields();
                ShowSuccessfulMessageBox();
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex);
            }
        }

        private void ShowWarningMessageBox(Exception ex)
        {
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void clearFields()
        {
            nameField.Clear();
            ageField.ResetText();
            emailField.Clear(); ;
            contactField.ResetText();
            bioField.Clear();
            searchField.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchField.Text)) return;

            if (authorRdBtn.Checked)
            {
                try
                {
                    AuthorController<Author> authorController = new AuthorController<Author>();
                    var result = authorController.SearchRecord(searchField.Text);

                    if (result == null)
                    {
                        MessageBox.Show("No Record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridView.DataSource = result;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    clearFields();
                }
            }
            else if (bookRdBtn.Checked)
            {
                try
                {
                    BookController<Book> bookController = new BookController<Book>();
                    var result = bookController.SearchRecord(searchField.Text);

                    if (result == null)
                    {
                        MessageBox.Show("No Record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridView.DataSource = result;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    clearFields();
                }
            }
            else if (publisherRdBtn.Checked)
            {
                try
                {
                    PublisherController<Publisher> publisherController = new PublisherController<Publisher>();
                    var result = publisherController.SearchRecord(searchField.Text);

                    if (result == null)
                    {
                        MessageBox.Show("No Record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridView.DataSource = result;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    clearFields();
                }
            }
            else
            {
                try
                {
                    MemberController<Member> memberController = new MemberController<Member>();
                    var result = memberController.SearchRecord(searchField.Text);

                    if (result == null)
                    {
                        MessageBox.Show("No Record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridView.DataSource = result;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    clearFields();
                }
            }
        }

        private void authorsMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AuthorController<Author> authorController = new AuthorController<Author>();
                dataGridView.DataSource = authorController.GetAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void showAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BookController<Book> publisherController = new BookController<Book>();
                dataGridView.DataSource = publisherController.GetAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OnDoubleClickRemoveData(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    string email = dataGridView.Rows[row.Index].Cells[3].Value.ToString()!;

                    var result = MessageBox.Show("This action cannot be undone. Do you really want to perform this operation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        new AuthorController<Author>().DeleteRecord(email);
                        dataGridView.Rows.RemoveAt(row.Index);
                    }
                }
            }
        }

        private void showPublishersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PublisherController<Publisher> publisherController = new PublisherController<Publisher>();
                dataGridView.DataSource = publisherController.GetAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void allMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MemberController<Member> publisherController = new MemberController<Member>();
                dataGridView.DataSource = publisherController.GetAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void showMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BookIssueController<BookIssue> bookIssueController = new BookIssueController<BookIssue>();
                dataGridView.DataSource = bookIssueController.GetAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void allExpiredBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BookIssueController<BookIssue> bookIssueController = new BookIssueController<BookIssue>();
                dataGridView.DataSource = bookIssueController.GetAllExpiredIssueBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Fahad Zia Khan (11939).", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void bookAuthorField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookPublisherField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberNameFieldTextChanged(object sender, EventArgs e)
        {

        }

        private void memberAddressFieldTextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}