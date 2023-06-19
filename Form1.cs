namespace Assignment_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using Microsoft.VisualBasic.Devices;
            using System.Reflection;

namespace Assign2_L2P
    {
        //Francis Mc Nabola
        // 22210289
        // Assignment2, Booking application form for L2P. Form allows front of house sales team to generate pricing and bookings.

        public partial class L2PForm : Form
        {
            public L2PForm()
            {
                InitializeComponent();
            }

            //setting constant string and decimal values for calucations.
            const string COURSE1 = "C# Fundamentals", COURSE2 = "C# Basic for Beginners", COURSE3 = "C# Intermediate",
            COURSE4 = "Advanced Topics", COURSE5 = "ASP.NET with C# Part A", COURSE6 = "ASP.NET with C# Part B";


            const int COURSE1COST = 900, COURSE2COST = 1500, COURSE3COST = 1800, COURSE4COST = 2300,
            COURSE5COST = 1250, COURSE6COST = 1250, COURSE1DAYS = 2, COURSE2DAYS = 4, COURSE3DAYS = 4, COURSE4DAYS = 2,
            COURSE5DAYS = 5, COURSE6DAYS = 5;

            const string LOCATION1 = "Belmullet", LOCATION2 = "Clifden", LOCATION3 = "Cork", LOCATION4 = "Dublin",
            LOCATION5 = "Killarney", LOCATION6 = "LetterKenny", LOCATION7 = "Sigo";

            const decimal LOCATION1COST = 219.99M, LOCATION2COST = 119.99M, LOCATION3COST = 149.99M, LOCATION4COST = 179.99M,
            LOCATION5COST = 149.99M, LOCATION6COST = 89.99M, LOCATION7COST = 119.99M, GROUPDISCOUNT = .075M,
            CERTIFICATEPRICE = 39.99M, MASTERSUITECOST = 99.99M, EXECUTIVECOST = 69.99M, JUNIORCOST = 49.99M;

            int NumAttendees, TotalBookings, TotalNumOfDisocunts = 0;
            decimal AvgTransaction, OverallCost, OverallEnrollmentFees, OverallLodgingFees, OverallOptionalFees, OverallValue;

            string Course = "", Location = "";

            private void DisplayButton_Click(object sender, EventArgs e)

            {
                //Setting local variables.

                int CourseIndex = 0, LocationIndex = 0;
                decimal CoursePrice = 0, LocationPrice = 0, CourseDays = 0, RoomCost = 0,
                DiscountPrice = 0, Optionalcost = 0, CERTIFICATEPRICE = 0, EnrollmentPrice, AvgRevenue;


                SummaryButton.Enabled = false;

                //using switch statement to pick which values from both list boxes.

                switch (CourseIndex)
                {
                    case 0: Course = COURSE1; CoursePrice = COURSE1COST; CourseDays = COURSE1DAYS; break;
                    case 1: Course = COURSE2; CoursePrice = COURSE2COST; CourseDays = COURSE2DAYS; break;
                    case 2: Course = COURSE3; CoursePrice = COURSE3COST; CourseDays = COURSE3DAYS; break;
                    case 3: Course = COURSE4; CoursePrice = COURSE4COST; CourseDays = COURSE4DAYS; break;
                    case 4: Course = COURSE5; CoursePrice = COURSE5COST; CourseDays = COURSE5DAYS; break;
                    case 5: Course = COURSE6; CoursePrice = COURSE6COST; CourseDays = COURSE6DAYS; break;


                }

                switch (LocationIndex)
                {
                    case 0: Location = LOCATION1; LocationPrice = LOCATION1COST; break;
                    case 1: Location = LOCATION2; LocationPrice = LOCATION2COST; break;
                    case 2: Location = LOCATION3; LocationPrice = LOCATION3COST; break;
                    case 3: Location = LOCATION4; LocationPrice = LOCATION4COST; break;
                    case 4: Location = LOCATION5; LocationPrice = LOCATION5COST; break;
                    case 5: Location = LOCATION6; LocationPrice = LOCATION6COST; break;
                    case 7: Location = LOCATION7; LocationPrice = LOCATION7COST; break;

                }

                if ((CourseListBox.SelectedIndex != -1))
                {


                    if ((LocationListBox.SelectedIndex != -1))
                    {
                        CourseIndex = CourseListBox.SelectedIndex;
                        LocationIndex = LocationListBox.SelectedIndex;


                        try
                        {
                            NumAttendees = int.Parse(AttendeesTxtBox.Text);



                            if (NumAttendees >= 3)
                            {

                                TotalNumOfDisocunts = TotalNumOfDisocunts + 1;

                            }

                            //Using if else to see if radio buttons and check boxes are checked.

                            if (CertificateCheckBox.Checked)

                            {
                                Optionalcost = 39.99m;
                            }

                            if (MasterSuiteButton.Checked)

                            {
                                Optionalcost = 99.99m;
                            }


                            if (ExecutiveSuiteButton.Checked)

                            {
                                Optionalcost = 69.99m;
                            }

                            if (JuniorSuiteButton.Checked)
                            {
                                Optionalcost = 49.99m;
                            }

                            //Calculations for Display Field.

                            RoomCost = LocationPrice * CourseDays;

                            EnrollmentPrice = CoursePrice * NumAttendees;

                            OverallCost = (EnrollmentPrice + Optionalcost + RoomCost);


                            CourseOutputLabel.Text = Course;
                            EnrollmentOutputLabel.Text = EnrollmentPrice.ToString("C2");
                            LodgingOutput.Text = RoomCost.ToString("C2");
                            OverallOutputLabel.Text = OverallCost.ToString("C2");
                            OptionalCostOutputLabel.Text = Optionalcost.ToString("C2");


                            SummaryButton.Enabled = false;
                            DisplayPanel.Visible = true;

                            // Calcualtions for summary table.

                            OverallValue = OverallCost + 1;

                            OverallEnrollmentFees = CoursePrice * NumAttendees;

                            OverallLodgingFees = LocationPrice * CourseDays;

                            OverallOptionalFees = OverallOptionalFees + (Optionalcost + CERTIFICATEPRICE);

                            TotalBookings = TotalBookings + 1;

                            AvgTransaction = ((OverallLodgingFees + OverallOptionalFees + OverallEnrollmentFees) / TotalBookings);





                            ValueBookingOutputLabel.Text = OverallValue.ToString("C2");

                            EnrollmentFeesOutputLabel.Text = OverallEnrollmentFees.ToString("C2");

                            LodgingOutputLabel.Text = OverallLodgingFees.ToString("C2");

                            RoomAndCertificateOutputLabel.Text = OverallOptionalFees.ToString("C2");

                            DiscountOutputLabel.Text = TotalNumOfDisocunts.ToString();

                            AvgRevenueOutputLabel.Text = AvgTransaction.ToString("C2");








                            void BookButton_Click(object sender, EventArgs e)
                            {
                                //confirming booking for user

                                SummaryButton.Enabled = true;
                                DisplayPanel.Visible = false;
                                MessageBox.Show("Booking Confirmend!" + "\n" + "\n" + "Course:" + Course + "\n" + "\n" + "Location:" +
                                Location + "\n" + "\n" + "Total Cost:" + OverallCost.ToString("C2"));




                            }
                        }
                        catch
                        {
                            MessageBox.Show("Please enter numercial value for Attendees", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            AttendeesTxtBox.Focus();
                            AttendeesTxtBox.SelectAll();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Please Select a Location", "Location Needed",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LocationListBox.Focus();

                    }

                }
                else
                {
                    MessageBox.Show("Please Select a Course", "Course Needed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CourseListBox.Focus();

                }

            }

            private void BookButton_Click(object sender, EventArgs e)
            {
                //confirming booking for user

                SummaryButton.Enabled = true;
                DisplayPanel.Visible = false;
                MessageBox.Show("Booking Confirmend!" + "\n" + "\n" + "Course:" + Course + "\n" + "\n" + "Location:" +
                Location + "\n" + "\n" + "Total Cost:" + OverallCost.ToString("C"));



            }


            private void SummaryButton_Click(object sender, EventArgs e)
            {
                //Toggling with different views to just show summary table.

                SummaryGroupBox.Visible = true;
                DisplayButton.Enabled = false;
                BookButton.Enabled = false;
                DisplayPanel.Visible = false;


            }
            private void ClearButton_Click(object sender, EventArgs e)
            {
                //Resetting forms values for fresh form for user.

                SummaryGroupBox.Visible = false;
                DisplayButton.Enabled = true;
                BookButton.Enabled = true;
                AttendeesTxtBox.Text = null;
                CertificateCheckBox.Checked = false;
                MasterSuiteButton.Checked = false;
                ExecutiveSuiteButton.Checked = false;
                JuniorSuiteButton.Checked = false;
                LocationListBox.ClearSelected();
                CourseListBox.ClearSelected();
                DisplayPanel.Visible = false;

                ValueBookingOutputLabel.Text = "0";
                EnrollmentFeesOutputLabel.Text = "0";
                LodgingOutputLabel.Text = "0";
                RoomAndCertificateOutputLabel.Text = "0";
                DiscountOutputLabel.Text = "0";
                AvgRevenueOutputLabel.Text = "0";

                CourseOutputLabel.Text = "0";
                EnrollmentOutputLabel.Text = "0";
                LodgingOutputLabel.Text = "0";
                OptionalCostOutputLabel.Text = "0";
                OverallOutputLabel.Text = "0";

            }


            private void ExitButton_Click(object sender, EventArgs e)
            {
                //Closing of form.
                this.Close();
            }


        }

    }
}
}