using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutomailDTO
    {
        private int ID;

        private string SOLD_TO_NUMBER;
        private string SOLD_TO_CUSTOMER;
        private string BILL_TO_NUMBER;
        private string BILL_TO_CUSTOMER;
        private string BILL_COUNTRY;

        private string SHIP_TO_CUSTOMER;
        private string SHIP_COUNTRY;
        private string CS;
        private string ORDER_NUMBER;
        private string LINE_NUMBER;

        private string CUST_PO_NUMBER;
        private string ORDER_TYPE_NAME;
        private string ORDER_SOURCE_NAME;
        private string CURRENCY_CODE;
        private string PAYMENT_TERM;

        private string H_STATUS;
        private string ORDERED_DATE;
        private string REQUEST_DATE;
        private string PROMISE_DATE;
        private string SCHEDULE_SHIP_DATE;

        private string CREATION_DATE;
        private string BOOKED_DATE;
        private string SHIPMENT_NUMBER;
        private string SET_NAME;
        private string FLOW_STATUS_CODE;

        private string QTY;
        private string PRICE;
        private string AMT;
        private string LIST_PRICE;
        private string MODIFIER_NAME;

        private string ORDERED_ITEM;
        private string CUSTOMER_ITEM;
        private string ITEM;
        private string ITEM_DESC;
        private string PROGRAM_NAME;

        private string PLANNER_CODE;
        private string ATO;
        private string MAKEBUY;
        private string INVOICE_LINE_INSTRUCTIONS;
        private string PRODUCTION_TYPE;

        private string DEPT_CODE;
        private string THERMAL_TYPE;
        private string CREDIT;
        private string HEADER_HOLD;
        private string LINE_HOLD;

        private string RESERVE_QTY;
        private string NOTFULFILL_QTY;
        private string DESCRIPTION;
        private string SHIP_INSTR;
        private string SHIP_METHOD_MEANING;

        private string FREIGHT_TERMS;
        private string DELIVERY_UPDATE_DATE;
        private string PICKED;
        private string PICK_DATE;
        private string DELIVERY_ID;

        private string WAYBILL;
        private string DELIVERY_STATUS;
        private string SUBINV;
        private string JOB_NAME;
        private string SZ_JOB_NAME;

        private string DJ_CREATION_DATE;
        private string SCHEDULE_GROUP_NAME;
        private string RELEASED_DATE;
        private string SCHEDULED_COMPLETION_DATE;
        private string DJ_STATUS;

        private string PRINT;
        private string PRINT_DATE;
        private string LAST_UPDATE;
        private string SEQ_NUM;
        private string OPERATION_DEPT;

        private string OPERATION_DESCRIPTION;
        private string PO_NUM;
        private string LINE_NUM;
        private string APPROVED_FLAG;
        private string APPROVED_STATUS;

        private string VENDOR_NAME;
        private string PO_BUYER_NAME;
        private string PO_LINE_CREATION_DATE;
        private string NEED_BY_DATE;
        private string PROMISE_DATE_2;

        private string SHIP_FROM_ORG_ID;
        private string INVENTORY_ITEM_ID;
        private string LAST_UPDATED_BY;
        private string LAST_UPDATE_DATE;
        private string FG;

        private string PRODFG;
        private string MO;
        private string PO;
        private string PACKING_INSTR;
        private string SPECIAL_INSTRUCTIONS;

        private string VIRABLE_BREAKDOWN_INSTRUCTIONS;
        private string MFG_NOTE;
        private string PRODUCTION_METHOD;
        private string D;
        private DateTime CREATEDDATE;

        public int Id
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        //
        public string SoldToNumber
        {
            get
            {
                return SOLD_TO_NUMBER;
            }

            set
            {
                SOLD_TO_NUMBER = value;
            }
        }

        public string SoldToCustomer
        {
            get
            {
                return SOLD_TO_CUSTOMER;
            }

            set
            {
                SOLD_TO_CUSTOMER = value;
            }
        }

        public string BillToNumber
        {
            get
            {
                return BILL_TO_NUMBER;
            }

            set
            {
                BILL_TO_NUMBER = value;
            }
        }

        public string BillToCustomer
        {
            get
            {
                return BILL_TO_CUSTOMER;
            }

            set
            {
                BILL_TO_CUSTOMER = value;
            }
        }

        public string BillToCountry
        {
            get
            {
                return BILL_COUNTRY;
            }

            set
            {
                BILL_COUNTRY = value;
            }
        }

        //
        public string ShiptoCustomer
        {
            get
            {
                return SHIP_TO_CUSTOMER;
            }

            set
            {
                SHIP_TO_CUSTOMER = value;
            }
        }

        public string ShiptoCountry
        {
            get
            {
                return SHIP_COUNTRY;
            }

            set
            {
                SHIP_COUNTRY = value;
            }
        }

        public string Cs
        {
            get
            {
                return CS;
            }

            set
            {
                CS = value;
            }
        }

        public string OrderNumber
        {
            get
            {
                return ORDER_NUMBER;
            }

            set
            {
                ORDER_NUMBER = value;
            }
        }

        public string LineNumber
        {
            get
            {
                return LINE_NUMBER;
            }

            set
            {
                LINE_NUMBER = value;
            }
        }

        //
        public string CustPoNumber
        {
            get
            {
                return CUST_PO_NUMBER;
            }

            set
            {
                CUST_PO_NUMBER = value;
            }
        }

        public string OrderTypeName
        {
            get
            {
                return ORDER_TYPE_NAME;
            }

            set
            {
                ORDER_TYPE_NAME = value;
            }
        }

        public string OrderSourceName
        {
            get
            {
                return ORDER_SOURCE_NAME;
            }

            set
            {
                ORDER_SOURCE_NAME = value;
            }
        }

        public string CurrencyCode
        {
            get
            {
                return CURRENCY_CODE;
            }

            set
            {
                CURRENCY_CODE = value;
            }
        }

        public string PaymentTerm
        {
            get
            {
                return PAYMENT_TERM;
            }

            set
            {
                PAYMENT_TERM = value;
            }
        }
        
        //
        public string HStatus
        {
            get
            {
                return H_STATUS;
            }

            set
            {
                H_STATUS = value;
            }
        }

        public string OrderedDate
        {
            get
            {
                return ORDERED_DATE;
            }

            set
            {
                ORDERED_DATE = value;
            }
        }

        public string RequestDate
        {
            get
            {
                return REQUEST_DATE;
            }

            set
            {
                REQUEST_DATE = value;
            }
        }

        public string PromiseDate
        {
            get
            {
                return PROMISE_DATE;
            }

            set
            {
                PROMISE_DATE = value;
            }
        }

        public string ScheduleShipDate
        {
            get
            {
                return SCHEDULE_SHIP_DATE;
            }

            set
            {
                SCHEDULE_SHIP_DATE = value;
            }
        }

        //
        public string CreationDate
        {
            get
            {
                return CREATION_DATE;
            }

            set
            {
                CREATION_DATE = value;
            }
        }

        public string BookedDate
        {
            get
            {
                return BOOKED_DATE;
            }

            set
            {
                BOOKED_DATE = value;
            }
        }

        public string ShipmentNumber
        {
            get
            {
                return SHIPMENT_NUMBER;
            }

            set
            {
                SHIPMENT_NUMBER = value;
            }
        }

        public string SetName
        {
            get
            {
                return SET_NAME;
            }

            set
            {
                SET_NAME = value;
            }
        }

        public string FlowStatusCode
        {
            get
            {
                return FLOW_STATUS_CODE;
            }

            set
            {
                FLOW_STATUS_CODE = value;
            }
        }

        //
        public string Qty
        {
            get
            {
                return QTY;
            }

            set
            {
                QTY = value;
            }
        }

        public string Price
        {
            get
            {
                return PRICE;
            }

            set
            {
                PRICE = value;
            }
        }

        public string Amt
        {
            get
            {
                return AMT;
            }

            set
            {
                AMT = value;
            }
        }

        public string ListPrice
        {
            get
            {
                return LIST_PRICE;
            }

            set
            {
                LIST_PRICE = value;
            }
        }

        public string ModifierName
        {
            get
            {
                return MODIFIER_NAME;
            }

            set
            {
                MODIFIER_NAME = value;
            }
        }

        //
        public string OrderedItem
        {
            get
            {
                return ORDERED_ITEM;
            }

            set
            {
                ORDERED_ITEM = value;
            }
        }

        public string CustomerItem
        {
            get
            {
                return CUSTOMER_ITEM;
            }

            set
            {
                CUSTOMER_ITEM = value;
            }
        }

        public string Item
        {
            get
            {
                return ITEM;
            }

            set
            {
                ITEM = value;
            }
        }

        public string ItemDesc
        {
            get
            {
                return ITEM_DESC;
            }

            set
            {
                ITEM_DESC = value;
            }
        }

        public string ProgramName
        {
            get
            {
                return PROGRAM_NAME;
            }

            set
            {
                PROGRAM_NAME = value;
            }
        }

        //
        public string PlannerCode
        {
            get
            {
                return PLANNER_CODE;
            }

            set
            {
                PLANNER_CODE = value;
            }
        }

        public string Ato
        {
            get
            {
                return ATO;
            }

            set
            {
                ATO = value;
            }
        }

        public string Makebuy
        {
            get
            {
                return MAKEBUY;
            }

            set
            {
                MAKEBUY = value;
            }
        }

        public string InvoiceLineInstructions
        {
            get
            {
                return INVOICE_LINE_INSTRUCTIONS;
            }

            set
            {
                INVOICE_LINE_INSTRUCTIONS = value;
            }
        }

        public string ProductionType
        {
            get
            {
                return PRODUCTION_TYPE;
            }

            set
            {
                PRODUCTION_TYPE = value;
            }
        }

        //
        public string DeptCode
        {
            get
            {
                return DEPT_CODE;
            }

            set
            {
                DEPT_CODE = value;
            }
        }

        public string ThermalType
        {
            get
            {
                return THERMAL_TYPE;
            }

            set
            {
                THERMAL_TYPE = value;
            }
        }

        public string Credit
        {
            get
            {
                return CREDIT;
            }

            set
            {
                CREDIT = value;
            }
        }

        public string HeaderHold
        {
            get
            {
                return HEADER_HOLD;
            }

            set
            {
                HEADER_HOLD = value;
            }
        }

        public string LineHold
        {
            get
            {
                return LINE_HOLD;
            }

            set
            {
                LINE_HOLD = value;
            }
        }

        //
        public string ReserveQty
        {
            get
            {
                return RESERVE_QTY;
            }

            set
            {
                RESERVE_QTY = value;
            }
        }

        public string NotfulfillQty
        {
            get
            {
                return NOTFULFILL_QTY;
            }

            set
            {
                NOTFULFILL_QTY = value;
            }
        }

        public string Description
        {
            get
            {
                return DESCRIPTION;
            }

            set
            {
                DESCRIPTION = value;
            }
        }

        public string ShipInstr
        {
            get
            {
                return SHIP_INSTR;
            }

            set
            {
                SHIP_INSTR = value;
            }
        }

        public string ShipMethodMeaning
        {
            get
            {
                return SHIP_METHOD_MEANING;
            }

            set
            {
                SHIP_METHOD_MEANING = value;
            }
        }

        //
        public string FreightTerms
        {
            get
            {
                return FREIGHT_TERMS;
            }

            set
            {
                FREIGHT_TERMS = value;
            }
        }

        public string DeliveryUpdateDate
        {
            get
            {
                return DELIVERY_UPDATE_DATE;
            }

            set
            {
                DELIVERY_UPDATE_DATE = value;
            }
        }

        public string Picked
        {
            get
            {
                return PICKED;
            }

            set
            {
                PICKED = value;
            }
        }

        public string PickDate
        {
            get
            {
                return PICK_DATE;
            }

            set
            {
                PICK_DATE = value;
            }
        }

        public string DeliveryId
        {
            get
            {
                return DELIVERY_ID;
            }

            set
            {
                DELIVERY_ID = value;
            }
        }

        //
        public string Waybill
        {
            get
            {
                return WAYBILL;
            }

            set
            {
                WAYBILL = value;
            }
        }

        public string DeliveryStatus
        {
            get
            {
                return DELIVERY_STATUS;
            }

            set
            {
                DELIVERY_STATUS = value;
            }
        }

        public string Subinv
        {
            get
            {
                return SUBINV;
            }

            set
            {
                SUBINV = value;
            }
        }

        public string JobName
        {
            get
            {
                return JOB_NAME;
            }

            set
            {
                JOB_NAME = value;
            }
        }

        public string SzJobName
        {
            get
            {
                return SZ_JOB_NAME;
            }

            set
            {
                SZ_JOB_NAME = value;
            }
        }

        //
        public string DjCreationDate
        {
            get
            {
                return DJ_CREATION_DATE;
            }

            set
            {
                DJ_CREATION_DATE = value;
            }
        }

        public string ScheduleGroupName
        {
            get
            {
                return SCHEDULE_GROUP_NAME;
            }

            set
            {
                SCHEDULE_GROUP_NAME = value;
            }
        }

        public string ReleasedDate
        {
            get
            {
                return RELEASED_DATE;
            }

            set
            {
                RELEASED_DATE = value;
            }
        }

        public string ScheduledCompletionDate
        {
            get
            {
                return SCHEDULED_COMPLETION_DATE;
            }

            set
            {
                SCHEDULED_COMPLETION_DATE = value;
            }
        }

        public string DjStatus
        {
            get
            {
                return DJ_STATUS;
            }

            set
            {
                DJ_STATUS = value;
            }
        }

        //
        public string Print
        {
            get
            {
                return PRINT;
            }

            set
            {
                PRINT = value;
            }
        }

        public string PrintDate
        {
            get
            {
                return PRINT_DATE;
            }

            set
            {
                PRINT_DATE = value;
            }
        }

        public string LastUpdate
        {
            get
            {
                return LAST_UPDATE;
            }

            set
            {
                LAST_UPDATE = value;
            }
        }

        public string SeqNum
        {
            get
            {
                return SEQ_NUM;
            }

            set
            {
                SEQ_NUM = value;
            }
        }

        public string OperationDept
        {
            get
            {
                return OPERATION_DEPT;
            }

            set
            {
                OPERATION_DEPT = value;
            }
        }

        //
        public string OperationDescription
        {
            get
            {
                return OPERATION_DESCRIPTION;
            }

            set
            {
                OPERATION_DESCRIPTION = value;
            }
        }

        public string PoNum
        {
            get
            {
                return PO_NUM;
            }

            set
            {
                PO_NUM = value;
            }
        }

        public string LineNum
        {
            get
            {
                return LINE_NUM;
            }

            set
            {
                LINE_NUM = value;
            }
        }

        public string ApprovedFlag
        {
            get
            {
                return APPROVED_FLAG;
            }

            set
            {
                APPROVED_FLAG = value;
            }
        }

        public string ApprovedStatus
        {
            get
            {
                return APPROVED_STATUS;
            }

            set
            {
                APPROVED_STATUS = value;
            }
        }

        //
        public string VendorName
        {
            get
            {
                return VENDOR_NAME;
            }

            set
            {
                VENDOR_NAME = value;
            }
        }

        public string PoBuyerName
        {
            get
            {
                return PO_BUYER_NAME;
            }

            set
            {
                PO_BUYER_NAME = value;
            }
        }

        public string PoLineCreationDate
        {
            get
            {
                return PO_LINE_CREATION_DATE;
            }

            set
            {
                PO_LINE_CREATION_DATE = value;
            }
        }

        public string NeedByDate
        {
            get
            {
                return NEED_BY_DATE;
            }

            set
            {
                NEED_BY_DATE = value;
            }
        }

        public string PromiseDate2
        {
            get
            {
                return PROMISE_DATE_2;
            }

            set
            {
                PROMISE_DATE_2 = value;
            }
        }

        // 
        public string ShipFromOrgId
        {
            get
            {
                return SHIP_FROM_ORG_ID;
            }

            set
            {
                SHIP_FROM_ORG_ID = value;
            }
        }

        public string InventoryItemId
        {
            get
            {
                return INVENTORY_ITEM_ID;
            }

            set
            {
                INVENTORY_ITEM_ID = value;
            }
        }

        public string LastUpdatedBy
        {
            get
            {
                return LAST_UPDATED_BY;
            }

            set
            {
                LAST_UPDATED_BY = value;
            }
        }

        public string LastUpdateDate
        {
            get
            {
                return LAST_UPDATE_DATE;
            }

            set
            {
                LAST_UPDATE_DATE = value;
            }
        }

        public string Fg
        {
            get
            {
                return FG;
            }

            set
            {
                FG = value;
            }
        }

        //
        public string Prodfg
        {
            get
            {
                return PRODFG;
            }

            set
            {
                PRODFG = value;
            }
        }

        public string Mo
        {
            get
            {
                return MO;
            }

            set
            {
                MO = value;
            }
        }

        public string Po
        {
            get
            {
                return PO;
            }

            set
            {
                PO = value;
            }
        }

        public string PackingInstr
        {
            get
            {
                return PACKING_INSTR;
            }

            set
            {
                PACKING_INSTR = value;
            }
        }

        public string SpecialInstructions
        {
            get
            {
                return SPECIAL_INSTRUCTIONS;
            }

            set
            {
                SPECIAL_INSTRUCTIONS = value;
            }
        }

        //
        public string VirableBreakdownInstructions
        {
            get
            {
                return VIRABLE_BREAKDOWN_INSTRUCTIONS;
            }

            set
            {
                VIRABLE_BREAKDOWN_INSTRUCTIONS = value;
            }
        }

        public string MfgNote
        {
            get
            {
                return MFG_NOTE;
            }

            set
            {
                MFG_NOTE = value;
            }
        }

        public string ProductionMethod
        {
            get
            {
                return PRODUCTION_METHOD;
            }

            set
            {
                PRODUCTION_METHOD = value;
            }
        }

        public string d
        {
            get
            {
                return D;
            }

            set
            {
                D = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return CREATEDDATE;
            }

            set
            {
                CREATEDDATE = value;
            }
        }

        // constructor
        public AutomailDTO()
        {

        }

    }
}
