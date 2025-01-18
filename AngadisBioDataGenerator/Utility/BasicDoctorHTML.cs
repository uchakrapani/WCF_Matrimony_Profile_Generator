using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2;

namespace AngadisBioDataGenerator.Utility
{
	public class BasicDoctorHTML
	{
		public static string BasicDoctor(UserModel record, string imageSource)
		{
			// Generate HTML content using the record data
			return $@"<!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Company Info Card</title>
                        <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f8f9fa;
                            }}

                            .a4-page {{
                                max-width: 210mm;
                                margin: 0 auto;
                                padding: 20px;
                                background-color: #fff;
                                border: 1px solid #ddd;
                            }}

                            .header {{
                                border-bottom: 2px solid #000;
                                padding-bottom: 10px;
                                margin-bottom: 20px;
                                text-align: center;
                            }}

                            .contact-info,
                            .address {{
                                font-size: 0.9rem;
                                margin-bottom: 5px;
                            }}

                            .card-section {{
                                margin-bottom: 20px;
                                display: flex;
                                align-items: stretch;
                            }}

                            .card-title {{
                                font-size: 1.5rem;
                                font-weight: bold;
                                text-align: center;
                                margin-bottom: 20px;
                            }}

                            .card-section img {{
                                width: 100%;
                                height: 350px;
                                object-fit: fill;
                            }}

                            .info-label {{
                                font-weight: bold;
                            }}

                            .info-value {{
                                margin-bottom: 10px;
                            }}

                            .footer {{
                                margin-top: 20px;
                                text-align: center;
                                padding: 10px;
                                border-top: 2px solid #000;
                            }}

                            /* Responsive adjustments */
                            @media (max-width: 768px) {{
                                .card-section {{
                                    flex-direction: column;
                                }}

                                .card-section .col-md-5,
                                .card-section .col-md-7 {{
                                    width: 100%;
                                    margin-bottom: 10px;
                                }}
                            }}

                            /* A4 Page Size for print */
                            @media print {{
                                @page {{
                                    size: A4;
                                    margin: 20mm;
                                }}

                                .a4-page {{
                                    width: 210mm;
                                    height: 297mm;
                                    padding: 20mm;
                                    margin: 0 auto;
                                    border: none;
                                    background-color: #fff;
                                }}

                                .footer {{
                                    page-break-after: always;
                                }}
                            }}
                            .title-with-line {{display: flex;
                                        align-items: center;
                                        margin-bottom: 20px;
                                    }}

                                    .title-with-line h2 {{margin: 0;
                                        padding-right: 10px;
                                        white-space: nowrap;
                                    }}

                                    .title-with-line .line {{flex - grow: 1;
                                        height: 1px;
                                        background-color: #000;
                                    }}
                        </style>
                    </head>
                    <body>
                        <div class='a4-page'>
                            <!-- Header Section -->
                            <div class='header'>
                                <img src='https://www.medicowedding.com/assets/logo/6045e6a9f473e1b7835f8c2cf5205d86.png' alt='Logo' class='img-fluid' style='max-height: 100px;'>
                                <div class='contact-info'><strong>Phone:</strong> +91-9019984122</div>
                                <div class='address'><strong>ANGADI's Lingayat Matrimony</strong><br/> No 52/A, 19th Main, 2nd Block Rajaji Nagara, Bangalore 560010</div>
                            </div>

                            <!-- Card Title -->
                            <div class='card-title'>{record.Firstname + " " + record.Lastname}({record.Matri_Id})</div>

                            <!-- Card Section -->
                            <div class='card-section row'>
                                <div class='col-md-5 d-flex'>
                                    <img src='{imageSource + record.Photo1}' alt='Image' class='img-fluid align-self-stretch'>
                                </div>
                                <div class='col-md-7'>
                                    <div class='row'>
                                        <div class=""title-with-line"">
                                            <h2>Personal Detail</h2>
                                            <div class=""line""></div>
                                        </div>
                                        <div class='col-4 info-label'>Username:</div>
                                        <div class='col-8 info-value'>{record.Username}</div>

                                        <div class='col-4 info-label'>Gender:</div>
                                        <div class='col-8 info-value'>{record.Gender}</div>

                                        <div class='col-4 info-label'>Birthdate:</div>
                                        <div class='col-8 info-value'>{record.Birthdate}</div>

                                        <div class='col-4 info-label'>Birthplace:</div>
                                        <div class='col-8 info-value'>{record.Birthplace}</div>

                                        <div class=""title-with-line"">
                                            <h2>Caste Detail</h2>
                                            <div class=""line""></div>
                                        </div>

                                        <div class='col-4 info-label'>Caste_Name:</div>
                                        <div class='col-8 info-value'>{record.Caste_Name}</div>

                                        <div class='col-4 info-label'>Subcaste:</div>
                                        <div class='col-8 info-value'>{record.Subcaste}</div>

                                        <div class=""title-with-line"">
                                            <h2>Edu & Occupation Detail</h2>
                                            <div class=""line""></div>
                                        </div>

                                        <div class='col-4 info-label'>Education_Name:</div>
                                        <div class='col-8 info-value'>{record.Education_Name}</div>

                                        <div class='col-4 info-label'>Occupation_Name:</div>
                                        <div class='col-8 info-value'>{record.Occupation_Name}</div>

                                        <div class='col-4 info-label'>Designation_Name:</div>
                                        <div class='col-8 info-value'>{record.Designation_Name}</div>
                                    </div>
                                </div>
                            </div>

                            <!-- Footer Section -->
                            <div class='footer'>
                                <div>For more info, contact: +91-9019984122 |  <a href='https://www.medicowedding.com/'>www.medicowedding.com/</a></div>
                                <img src='https://www.medicowedding.com/assets/logo/6045e6a9f473e1b7835f8c2cf5205d86.png' alt='Logo' class='img-fluid' style='max-height: 100px;'>
                            </div>
                        </div>

                        <!-- Bootstrap JS -->
                        <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js'></script>
                    </body>
                    </html>";
		}
	}
}
