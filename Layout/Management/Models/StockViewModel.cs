using System;

namespace Management
{
    public class StockViewModel
    {
        public int ID { get; set; }
        /// <summary>
        /// �w�s��UID
        /// </summary>
        public Guid UID { get; set; }
        /// <summary>
        /// ���O
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// ���O
        /// </summary>
        public Guid CategoryUid { get; set; }
        /// <summary>
        /// �Ƹ�
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// �~�W
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �W��
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// �w�s�ƶq
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// �Ҧb�a
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// �y�z�B�Ƶ�
        /// </summary>
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
