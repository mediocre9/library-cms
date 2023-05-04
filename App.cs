using _11939_Major_Agmnt_.controllers;
using _11939_Major_Agmnt_.models;

namespace _11939_Major_Agmnt_
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
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


        private void button3_onClick(object sender, EventArgs e)
        {
            try
            {
                string authorId = "";
                foreach (var author in authors)
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
                foreach (var publisher in publishers)
                {
                    foreach (var i in publisher)
                    {
                        if (i.Value.ToString() == bookPublisherField.Items[bookPublisherField.SelectedIndex].ToString())
                        {
                            pubId = i.Key;
                        }
                    }
                }


                new BookController<Book>().addRecord(
                    new Book(
                        bookTitleField.Text,
                        bookPriceField.Text,
                        authorId,
                        pubId
                    ));
                clearFields();
                MessageBox.Show("Operation successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void book_TabPageClick(object sender, EventArgs e)
        {
            loadData();
        }

        private void submit_PublisherBtn(object sender, EventArgs e)
        {
            try
            {
                new PublisherController<Publisher>().addRecord(
                    new Publisher(
                        publisherNameField.Text,
                        publisherAddressField.Text
                    ));
                clearFields();
                MessageBox.Show("Operation successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new MemberController<Member>().addRecord(
                    new Member(
                        memberNameField.Text,
                        memberAddressField.Text
                    ));
                clearFields();
                MessageBox.Show("Operation successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void click_BookIssueBtn(object sender, EventArgs e)
        {

        }

        private void memberNameFieldTextChanged(object sender, EventArgs e)
        {

        }

        private void memberAddressFieldTextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                new AuthorController<Author>().addRecord(
                    new Author(
                        nameField.Text,
                        int.Parse(ageField.Text),
                        maleRadioButton.Checked ? "Male" : "Female",
                        emailField.Text,
                        contactField.Text,
                        bioField.Text
                    ));
                clearFields();
                MessageBox.Show("Operation successful!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void clearFields()
        {
            nameField.Clear();
            ageField.ResetText();
            emailField.Clear(); ;
            contactField.ResetText();
            bioField.Clear();
        }

        List<Dictionary<string, string>> authors = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> publishers = new List<Dictionary<string, string>>();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            BookController<Book> bookController = new BookController<Book>();
            authors = bookController.getAuthorRecord()!;

            foreach (var author in authors)
            {
                foreach (var item in author)
                {
                    bookAuthorField.Items.Add(item.Value);
                }
            }



            publishers = bookController.getPublisherRecord()!;

            foreach (var publisher in publishers)
            {
                foreach (var item in publisher)
                {
                    bookPublisherField.Items.Add(item.Value);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (authorRdBtn.Checked)
            {
                try
                {
                    AuthorController<Author> authorController = new AuthorController<Author>();
                    dataGridView.DataSource = authorController.searchRecord(searchField.Text);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (bookRdBtn.Checked)
            {
                try
                {
                    BookController<Book> bookController = new BookController<Book>();
                    dataGridView.DataSource = bookController.searchRecord(searchField.Text);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (publisherRdBtn.Checked)
            {
                try
                {
                    PublisherController<Publisher> publisherController = new PublisherController<Publisher>();
                    dataGridView.DataSource = publisherController.searchRecord(searchField.Text);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                try
                {
                    MemberController<Member> memberController = new MemberController<Member>();
                    dataGridView.DataSource = memberController.searchRecord(searchField.Text);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void authorsMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AuthorController<Author> authorController = new AuthorController<Author>();
                dataGridView.DataSource = authorController.getAllRecords();
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
                dataGridView.DataSource = publisherController.getAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void showPublishersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PublisherController<Publisher> publisherController = new PublisherController<Publisher>();
                dataGridView.DataSource = publisherController.getAllRecords();
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
                dataGridView.DataSource = publisherController.getAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void showMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Fahad Zia Khan (11939). Copyright (c) 2023. All rights reserved.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bookAuthorField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookPublisherField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}