﻿namespace MVCTASK.Models
{
    public class Pager
    {
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }


        public int TotalPages { get; set; }

        public int Startpage { get; set; }

        public int Endpage { get; set; }


        public Pager() { 
        
        
        }


        public Pager(int totalitems,int page,int pageSize = 10)
        {
           
            int totalPages = (int)Math.Ceiling((decimal)totalitems / (decimal)pageSize);

            int currentPage = page;

            int startPage=currentPage -5 ;
            
            int endPage=currentPage +4 ;

            if (startPage <= 0)
            {
                endPage= endPage-(startPage-1);
                startPage= 1 ;

            }

            if (endPage > totalPages)
            {
                endPage= totalPages;

                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalitems;
            CurrentPage = currentPage;
            PageSize= pageSize;
            TotalPages = totalPages;
            Startpage= startPage;
            Endpage= endPage;





        }
        
    }
}
